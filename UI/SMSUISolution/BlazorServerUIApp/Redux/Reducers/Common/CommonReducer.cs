using BlazorServerUIApp.Redux.Actions.Common;
using BlazorServerUIApp.Redux.States.Common;
using Fluxor;

namespace BlazorServerUIApp.Redux.Reducers.Common
{
    public class CommonReducer
    {
        [ReducerMethod]
        public static PromptMessageState ReducerPromptMessageAction(PromptMessageState state, PromptMessageAction action) =>
            new(isSuccess: action.IsSuccess, isError: action.IsError, message: action.Message);

        [ReducerMethod]
        public static LoadingState ReducerShowLoadingAction(LoadingState state, ShowLoadingAction action) =>
            new(isLoading: true);

        [ReducerMethod]
        public static LoadingState ReducerHideLoadingAction(LoadingState state, HideLoadingAction action) =>
            new(isLoading: false);
    }
}
