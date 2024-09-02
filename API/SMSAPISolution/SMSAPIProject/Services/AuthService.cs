using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Helper;
using SMSAPIProject.Models.RequestModel.Auth;
using SMSAPIProject.Models.ResponseModel.Auth;
using SMSAPIProject.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SMSAPIProject.Services
{
    public class AuthService : IAuthService
    {
        private readonly SMS_Dev_DbContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(SMS_Dev_DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginRes> UserLogin(LoginReq request)
        {
            try
            {
                var response = new LoginRes();

                // Encryption Decryption Key
                var key = _configuration["AesKey"].ToString();
                string encryptedPassword = AesEncryptionDecryption.Encryption(key, request.Password.Trim());

                // Validating user
                var userDtl = await _context.UserDetails.Where(x => x.Email.ToLower().Trim() == request.Email.ToLower().Trim() && x.Password == encryptedPassword).FirstOrDefaultAsync();
                if (userDtl == null) 
                {
                    return new LoginRes()
                    {
                        Status = false,
                        Message = "Invalid credentials"
                    };
                }
                else if(userDtl.IsActive == false)
                {
                    return new LoginRes()
                    {
                        Status = false,
                        Message = "User is In-active"
                    };
                }

                #region Token creation
                // Getting expiryTime from appsetting
                int.TryParse(_configuration["Jwt:TokenExpiryInMinute"], out int tokenValidityInMinute);
                DateTime expiryDateTime = DateTime.Now.AddMinutes((tokenValidityInMinute == 0) ? 60 : tokenValidityInMinute);

                int.TryParse(_configuration["Jwt:RefreshTokenExpiryInMinute"], out int refreshTokenValidityInMinute);
                DateTime refreshExpiryDateTime = DateTime.Now.AddMinutes((refreshTokenValidityInMinute == 0) ? 60 : refreshTokenValidityInMinute);

                // Generate Token
                var tokenRequest = new GenerateTokenReq()
                {
                    UserId = userDtl.UserId,
                    RoleId = userDtl.RoleId,
                    FirstName = userDtl.FirstName,
                    LastName = userDtl.LastName,
                    ExpiaryDateTime = expiryDateTime
                };
                string accessToken = GenerateToken(tokenRequest);
                string refreshToken = GenerateRefreshToken();

                // Store refresh token
                userDtl.Token = refreshToken;
                userDtl.TokenExpiry = refreshExpiryDateTime;
                _context.UserDetails.Update(userDtl);
                _context.SaveChanges();

                response.Status = true;
                response.Message = "User login successfully";
                response.Data = new LoginResponseData();
                response.Data.UserId = userDtl.UserId;
                response.Data.RoleId = userDtl.RoleId;
                response.Data.SalutationId = userDtl.SalutationId;
                response.Data.FirstName = userDtl.FirstName;
                response.Data.LastName = userDtl.LastName;
                response.Data.Email = userDtl.Email;
                response.Data.Phone = userDtl.Phone;
                response.Data.Token = accessToken;
                response.Data.RefreshToken = refreshToken;
                response.Data.TokenExpiry = expiryDateTime;

                return response;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Custom Private Method

        private string GenerateToken(GenerateTokenReq generateTokenReq)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create claims details based on the user information
            Claim[] claims = new Claim[]
            {
                new Claim("UserId", generateTokenReq.UserId),
                new Claim("RoleId", generateTokenReq.RoleId == null ? "":generateTokenReq.RoleId.ToString()),
                new Claim("FirstName", generateTokenReq.FirstName),
                new Claim("LastName", generateTokenReq.LastName??""),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: generateTokenReq.ExpiaryDateTime,
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}
