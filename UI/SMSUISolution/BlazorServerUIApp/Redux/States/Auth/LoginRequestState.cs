using BlazorServerUIApp.Models.RequestModels.Auth;
using Fluxor;

namespace BlazorServerUIApp.Redux.States.Auth
{
    [FeatureState]
    public class LoginRequestState
    {
        public LoginReq LoginRequest { get; set; }
        public LoginRequestState()
        {
            LoginRequest = new LoginReq();
        }

        public LoginRequestState(LoginReq loginReq)
        {
            LoginRequest = loginReq;
        }
    }
}
