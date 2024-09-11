using Fluxor;

namespace BlazorServerUIApp.Redux.States.Common
{
    [FeatureState]
    public class PromptMessageState
    {
        public bool IsSuccess { get; }
        public bool IsError { get; }
        public string Message { get; } = string.Empty;
        public PromptMessageState()
        {
            IsSuccess = false;
            IsError = false;
            Message = string.Empty;
        }

        public PromptMessageState(bool isSuccess, bool isError, string message)
        {
            IsSuccess = isSuccess;
            IsError = isError;
            Message = message;
        }
    }
}
