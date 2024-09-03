using SMSAPIProject.Models.ResponseModel.Master;

namespace SMSAPIProject.Services.IServices
{
    public interface IMasterService
    {
        public Task<MasterRes> GetMasterData();
    }
}
