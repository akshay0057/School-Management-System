using BlazorServerUIApp.Models.ResponseModels.Master;

namespace BlazorServerUIApp.Redux.Actions.Master
{
    public class MasterDataAction
    {
        public MasterDataRes MasterData { get; set; }
        public MasterDataAction()
        {
            MasterData = new MasterDataRes();
        }

        public MasterDataAction(MasterDataRes masterDataRes)
        {
            MasterData = masterDataRes;
        }
    }
}
