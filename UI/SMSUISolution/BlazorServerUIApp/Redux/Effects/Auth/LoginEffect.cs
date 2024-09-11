using BlazorServerUIApp.Models.Constant;
using BlazorServerUIApp.Models.Enum;
using BlazorServerUIApp.Redux.Actions.Auth;
using BlazorServerUIApp.Redux.Actions.Common;
using BlazorServerUIApp.Services.IServices;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorServerUIApp.Redux.Effects.Auth
{
    public class LoginEffect
    {
        private readonly IAuthService _service;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        public LoginEffect(IAuthService service, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _service = service;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        [EffectMethod]
        public async Task HandleLoginActionAsync(LoginRequestAction action, IDispatcher dispatcher)
        {
            try
            {
                dispatcher.Dispatch(new AddComponentLoadingAction(AppConstant.LOADING_LOGIN_PAGE));
                var response = await _service.Login(action.LoginRequest);
                if(response != null && response.Status == true)
                {
                    if(response.Data != null)
                    {
                        await _localStorage.SetItem(LocalStorageItem.Token.ToString(), response.Data.Token);
                        await _localStorage.SetItem(LocalStorageItem.UserId.ToString(), response.Data.UserId);
                        await _localStorage.SetItem(LocalStorageItem.UserFirstName.ToString(), response.Data.FirstName);
                        await _localStorage.SetItem(LocalStorageItem.UserLastName.ToString(), response.Data.LastName);
                        await _localStorage.SetItem(LocalStorageItem.UserEmail.ToString(), response.Data.Email);

                        dispatcher.Dispatch(new PromptMessageAction(isSuccess: true, isError: false, message: response.Message));
                        _navigationManager.NavigateTo("dashboard");
                        return;
                    }
                    dispatcher.Dispatch(new PromptMessageAction(isSuccess: true, isError: false, message: response.Message));
                    return;
                }
                dispatcher.Dispatch(new PromptMessageAction(isSuccess: false, isError: true, message: response?.Error?.ErrorDescryption??""));
                return;
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new PromptMessageAction(isSuccess: false, isError: true, message: ex.Message));
            }
            finally
            {
                dispatcher.Dispatch(new RemoveComponentLoadingAction(AppConstant.LOADING_LOGIN_PAGE));
            }
        }
    }
}
