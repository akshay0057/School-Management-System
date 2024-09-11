using BlazorServerUIApp.Models.ResponseModels.Master;

namespace BlazorServerUIApp.Services.IServices
{
    public interface IMasterService
    {
        Task<MasterDataRes> GetMasterData();
    }
}
