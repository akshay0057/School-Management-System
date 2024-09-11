using BlazorServerUIApp.Redux.Actions.Common;
using BlazorServerUIApp.Redux.States.Common;
using Fluxor;

namespace BlazorServerUIApp.Redux.Effects.Common
{
    public class CommonEffect
    {
        [EffectMethod]
        public async Task HandleAddComponentLoadingActionAsync(AddComponentLoadingAction action, IDispatcher dispatcher)
        {
            try
            {
                dispatcher.Dispatch(new ShowLoadingAction());
                LoadingStore.GetInstance().AddLoadingComponent(action.Component);
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new HideLoadingAction());
                dispatcher.Dispatch(new PromptMessageAction(isSuccess: false, isError: true, message: ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleRemoveComponentLoadingActionAsync(RemoveComponentLoadingAction action, IDispatcher dispatcher)
        {
            try
            {
                var componentCount = LoadingStore.GetInstance().RemoveLoadingComponent(action.Component);
                if(componentCount == 0)
                {
                    dispatcher.Dispatch(new HideLoadingAction());
                }
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new HideLoadingAction());
                dispatcher.Dispatch(new PromptMessageAction(isSuccess: false, isError: true, message: ex.Message));
            }
        }
    }
}
