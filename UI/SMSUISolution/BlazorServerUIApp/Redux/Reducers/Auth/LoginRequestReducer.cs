using BlazorServerUIApp.Redux.Actions.Auth;
using BlazorServerUIApp.Redux.States.Auth;
using Fluxor;

namespace BlazorServerUIApp.Redux.Reducers.Auth
{
    public class LoginRequestReducer
    {
        [ReducerMethod]
        public static LoginRequestState ReducerLoginRequestAction(LoginRequestState state, LoginRequestAction action) =>
            new(loginReq: action.LoginRequest);
    }
}
