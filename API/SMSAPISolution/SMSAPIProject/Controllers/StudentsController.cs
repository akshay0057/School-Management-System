using Microsoft.AspNetCore.Mvc;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Helper;
using SMSAPIProject.Models.RequestModel.Student;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("studentlist")]
        public async Task<IActionResult> GetStudentList([FromQuery] StudentListReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetStudentList(request);
            return Ok(response);
        }

        [HttpGet("studentbyid")]
        public async Task<IActionResult> GetStudentDetailsById([FromQuery] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetStudentDetailsById(Id);
            return Ok(response);
        }

        [HttpPost("addupdatestudent")]
        public async Task<IActionResult> AddUpdateStudent([FromBody] AddUpdateStudentReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HeaderHelper.GetHeaderValue(HttpContext.Request, "LoginUserId");
            var response = await _service.AddUpdateStudent(request, userId);
            return Ok(response);
        }

        [HttpDelete("deletestudent")]
        public async Task<IActionResult> DeleteStudentById([FromQuery] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.DeleteStudentById(Id);
            return Ok(response);
        }
    }
}
