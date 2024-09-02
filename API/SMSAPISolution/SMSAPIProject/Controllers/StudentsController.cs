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
        public async Task<IActionResult> GetstudentList([FromQuery] StudentListReq request)
        {
            var response = await _service.GetstudentList(request);
            return Ok(response);
        }

        [HttpGet("studentbyid")]
        public async Task<IActionResult> GetStudentDetailsById([FromQuery] int Id)
        {
            var response = await _service.GetStudentDetailsById(Id);
            return Ok(response);
        }

        [HttpPost("addstudent")]
        public async Task<ActionResult<StudentDetail>> AddUpdateStudent([FromBody] AddUpdateStudentReq request)
        {
            string userId = HeaderHelper.GetHeaderValue(HttpContext.Request, "LoginUserId");
            var response = await _service.AddUpdateStudent(request, userId);
            return Ok(response);
        }

        [HttpDelete("deletestudent")]
        public async Task<IActionResult> DeleteStudentById([FromQuery] int Id)
        {
            var response = await _service.DeleteStudentById(Id);
            return Ok(response);
        }

    }
}
