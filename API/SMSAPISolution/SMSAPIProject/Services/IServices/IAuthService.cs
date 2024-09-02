using SMSAPIProject.Models.RequestModel.Auth;
using SMSAPIProject.Models.ResponseModel.Auth;

namespace SMSAPIProject.Services.IServices
{
    public interface IAuthService
    {
        public Task<LoginRes> UserLogin(LoginReq request);
    }
}
