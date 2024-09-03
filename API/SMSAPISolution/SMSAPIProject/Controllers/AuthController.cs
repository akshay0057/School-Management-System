using Microsoft.AspNetCore.Mvc;
using SMSAPIProject.Models.RequestModel.Auth;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginReq loginReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.UserLogin(loginReq);
            return Ok(response);
        }
    }
}
