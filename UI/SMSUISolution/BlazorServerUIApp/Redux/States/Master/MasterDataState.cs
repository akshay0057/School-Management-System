using BlazorServerUIApp.Models.ResponseModels.Master;
using Fluxor;

namespace BlazorServerUIApp.Redux.States.Master
{
    [FeatureState]
    public class MasterDataState
    {
        public MasterDataRes MasterData { get; }
        public MasterDataState()
        {
            MasterData = new MasterDataRes();
        }

        public MasterDataState(MasterDataRes masterDataRes)
        {
            MasterData = masterDataRes;
        }
    }
}
