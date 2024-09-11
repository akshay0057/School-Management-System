using BlazorServerUIApp.Redux.Actions.Master;
using BlazorServerUIApp.Redux.States.Master;
using Fluxor;

namespace BlazorServerUIApp.Redux.Reducers.Master
{
    public static class MasterDataReducer
    {
        [ReducerMethod]
        public static MasterDataState ReducerMasterDataAction(MasterDataState state, MasterDataAction action) =>
            new(masterDataRes: action.MasterData);
    }
}
