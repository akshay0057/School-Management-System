using BlazorServerUIApp.Redux.Actions.Auth;
using BlazorServerUIApp.Redux.States.Auth;
using Fluxor;

namespace BlazorServerUIApp.Redux.Reducers.Auth
{
    public class LoginResponseReducer
    {
        [ReducerMethod]
        public static LoginResponseState ReducerLoginResponseAction(LoginResponseState state, LoginResponseAction action) =>
            new(loginRes: action.LoginResponse);
    }
}
