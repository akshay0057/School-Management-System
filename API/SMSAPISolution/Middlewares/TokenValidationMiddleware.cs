using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public TokenValidationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Checking is token validation required for this endpoint
            bool isRequireTokenValidation = IsRequiredTokenValidation(context);
            if(isRequireTokenValidation)
            {
                // Get the token from the request
                string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "").Replace("bearer ", "");
                if (string.IsNullOrWhiteSpace(token))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token is required");
                    return;
                }

                // Get the LoginUserId from request
                string? userId = context.Request.Headers["LoginUserId"];
                if(string.IsNullOrWhiteSpace(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Required 'LoginUserId' header value not found.");
                    return;
                }

                // Access the app setting "JwtIssuer"
                string jwtIssuer = _configuration["Jwt:Issuer"];
                string jwtKey = _configuration["Jwt:Key"];
                string jwtAudience = _configuration["Jwt:Audience"];
                var (tokenStatus, tokenMessage) = IsValidToken(token, userId, jwtIssuer, jwtKey, jwtAudience);
                if (!tokenStatus)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync(tokenMessage);
                    return;
                }
            }
            await _next(context);
        }











        private bool IsRequiredTokenValidation(HttpContext context)
        {
            // You can implement your logic here to determine if token validation is required
            // based on the route, endpoint, or other conditions.
            // For example:      
            if (context.Request.Path.StartsWithSegments("/api/auth/login")
                || context.Request.Path.StartsWithSegments("/api/auth/sendotp")
                || context.Request.Path.StartsWithSegments("/api/auth/verifyotp")
                 || context.Request.Path.StartsWithSegments("/api/auth/resetpassword")
                 || context.Request.Path.StartsWithSegments("/api/auth/forgotpassword")
                 || context.Request.Path.StartsWithSegments("/api/auth/refreshtoken")
                )
                return false;

            return true;
        }

        private (bool, string) IsValidToken(string token, string userId, string issuer, string jwtKey, string jwtAudience)
        {
            var symmetricKey = jwtKey;
            if (symmetricKey == null)
                return (false, "Keys not found");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = jwtAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricKey)),
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                // Read token
                var tokenS = tokenHandler.ReadJwtToken(token);
                if(tokenS != null)
                {
                    Claim? claim = tokenS.Claims.FirstOrDefault(Claim => Claim.Type == "UserId");
                    if(claim != null)
                    {
                        string tokenUserId = claim.Value;
                        if(string.IsNullOrEmpty(tokenUserId) || tokenUserId.Trim() != userId.Trim())
                        {
                            return (false, "Unauthorized Token");
                        }
                    }
                    else
                    {
                        return (false, "Unauthorized Token");
                    }
                }
                else
                {
                    return (false, "Unauthorized Token");
                }

                tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
                return (true, "Valid Token");
            }
            catch (SecurityTokenExpiredException)
            {
                // Token has expired
                return (false, "Token has expired.");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                // Token signature is invalid
                return (false, "Token signature is invalid.");
            }
            catch (SecurityTokenValidationException)
            {
                // Token validation failed
                return (false, "Token validation failed.");
            }
            catch (Exception ex)
            {
                return (false, "Token validation failed.");
            }
        }
    }
}
