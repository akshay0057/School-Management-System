using BlazorServerUIApp.Models.RequestModels.Auth;
using BlazorServerUIApp.Models.ResponseModels.Auth;
using BlazorServerUIApp.Services.IServices;

namespace BlazorServerUIApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly CommonCallAPI _apiCall;
        public AuthService(CommonCallAPI apiCall)
        {
            _apiCall = apiCall;
        }

        public async Task<LoginRes> Login(LoginReq request)
        {
            try
            {
                var response = await _apiCall.CallApiAsync<LoginReq, LoginRes>("auth/login", HttpMethod.Post, request);
                return response;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
