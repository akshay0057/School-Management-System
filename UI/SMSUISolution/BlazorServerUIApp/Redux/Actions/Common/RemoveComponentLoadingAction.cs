namespace BlazorServerUIApp.Redux.Actions.Common
{
    public class RemoveComponentLoadingAction
    {
        public string Component { get; }
        public RemoveComponentLoadingAction(string component)
        {
            Component = component;
        }
    }
}
