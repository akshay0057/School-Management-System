namespace BlazorServerUIApp.Redux.Actions.Common
{
    public class AddComponentLoadingAction
    {
        public string Component { get; }
        public AddComponentLoadingAction(string component)
        {
            Component = component;
        }
    }
}
