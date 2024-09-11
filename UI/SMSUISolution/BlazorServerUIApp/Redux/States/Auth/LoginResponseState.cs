using BlazorServerUIApp.Models.ResponseModels.Auth;
using Fluxor;

namespace BlazorServerUIApp.Redux.States.Auth
{
    [FeatureState]
    public class LoginResponseState
    {
        public LoginRes LoginResponse { get; }
        public LoginResponseState()
        {
            LoginResponse = new LoginRes();
        }

        public LoginResponseState(LoginRes loginRes)
        {
            LoginResponse = loginRes;
        }
    }
}
