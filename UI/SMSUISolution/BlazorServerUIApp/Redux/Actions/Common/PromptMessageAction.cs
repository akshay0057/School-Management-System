namespace BlazorServerUIApp.Redux.Actions.Common
{
    public class PromptMessageAction
    {
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; } = string.Empty;
        public PromptMessageAction()
        {
            IsSuccess = false;
            IsError = false;
            Message = string.Empty;
        }

        public PromptMessageAction(bool isSuccess, bool isError, string message)
        {
            IsSuccess = isSuccess;
            IsError = isError;
            Message = message;
        }
    }
}
