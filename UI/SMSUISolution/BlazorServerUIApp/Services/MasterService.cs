using BlazorServerUIApp.Models.ResponseModels.Master;
using BlazorServerUIApp.Services.IServices;

namespace BlazorServerUIApp.Services
{
    public class MasterService : IMasterService
    {
        private readonly CommonCallAPI _apiCall;
        public MasterService(CommonCallAPI apiCall)
        {
            _apiCall = apiCall;
        }

        public async Task<MasterDataRes> GetMasterData()
        {
            try
            {
                var response = await _apiCall.CallApiAsync<object, MasterDataRes>("master/getmasterdata", HttpMethod.Get);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
