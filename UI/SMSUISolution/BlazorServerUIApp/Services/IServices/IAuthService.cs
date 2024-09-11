using BlazorServerUIApp.Models.RequestModels.Auth;
using BlazorServerUIApp.Models.ResponseModels.Auth;

namespace BlazorServerUIApp.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginRes> Login(LoginReq request);
    }
}
