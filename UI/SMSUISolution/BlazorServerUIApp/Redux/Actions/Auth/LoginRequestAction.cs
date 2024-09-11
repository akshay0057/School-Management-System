using BlazorServerUIApp.Models.RequestModels.Auth;

namespace BlazorServerUIApp.Redux.Actions.Auth
{
    public class LoginRequestAction
    {
        public LoginReq LoginRequest { get; set; }
        public LoginRequestAction()
        {
            LoginRequest = new LoginReq();
        }

        public LoginRequestAction(LoginReq loginReq)
        {
            LoginRequest = loginReq;
        }
    }
}
