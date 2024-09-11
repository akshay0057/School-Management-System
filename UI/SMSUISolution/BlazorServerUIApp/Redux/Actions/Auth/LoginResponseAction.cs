using BlazorServerUIApp.Models.ResponseModels.Auth;

namespace BlazorServerUIApp.Redux.Actions.Auth
{
    public class LoginResponseAction
    {
        public LoginRes LoginResponse { get; }
        public LoginResponseAction()
        {
            LoginResponse = new LoginRes();
        }

        public LoginResponseAction(LoginRes loginRes)
        {
            LoginResponse = loginRes;
        }
    }
}
