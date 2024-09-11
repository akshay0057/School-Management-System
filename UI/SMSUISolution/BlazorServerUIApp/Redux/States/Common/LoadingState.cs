using Fluxor;

namespace BlazorServerUIApp.Redux.States.Common
{
    [FeatureState]
    public class LoadingState
    {
        public bool IsLoading { get; set; } = false;
        public LoadingState()
        {
            IsLoading = false;
        }

        public LoadingState(bool isLoading)
        {
            IsLoading = isLoading;
        }
    }
}
