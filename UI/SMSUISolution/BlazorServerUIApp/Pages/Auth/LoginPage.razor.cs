using BlazorServerUIApp.Models.RequestModels.Auth;
using BlazorServerUIApp.Redux.Actions.Auth;

namespace BlazorServerUIApp.Pages.Auth
{
    public partial class LoginPage
    {
        private LoginReq request => _loginRequestState.Value.LoginRequest;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task OnClick_Login()
        {
            _dispatcher.Dispatch(new LoginRequestAction(request));
        }
    }
}
