namespace BlazorServerUIApp.Redux.States.Common
{
    public class LoadingStore
    {
        private LoadingStore()
        {
            
        }

        private static LoadingStore _instance;
        private List<string> _loadingComponent = new List<string>();

        public static LoadingStore GetInstance()
        {
            if(_instance == null)
                _instance = new LoadingStore();
            return _instance;
        }

        public void AddLoadingComponent(string componentName)
        {
            _loadingComponent.Add(componentName);
        }

        public int RemoveLoadingComponent(string componentName)
        {
            _loadingComponent.Remove(componentName);
            return _loadingComponent.Count;
        }
    }
}
