using Microsoft.AspNetCore.Mvc;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Controllers
{
    [Route("api/master")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly IMasterService _service;
        public MastersController(IMasterService service)
        {
            _service = service;
        }

        [HttpGet("getmasterdata")]
        public async Task<IActionResult> GetMasterData()
        {
            var response = await _service.GetMasterData();
            return Ok(response);
        }
    }
}
