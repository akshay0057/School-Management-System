using Microsoft.AspNetCore.Mvc;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Helper;
using SMSAPIProject.Models.RequestModel.Attendence;
using SMSAPIProject.Models.RequestModel.Student;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Controllers
{
    [Route("api/attendence")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private readonly IAttendenceService _service;
        public AttendenceController(IAttendenceService service)
        {
            _service = service;
        }

        [HttpPost("savestudentattendence")]
        public async Task<IActionResult> SaveStudentsAttendence([FromBody] SaveStudentAttendenceReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HeaderHelper.GetHeaderValue(HttpContext.Request, "LoginUserId");
            var response = await _service.SaveStudentsAttendence(request, userId);
            return Ok(response);
        }

        [HttpGet("studentattendencelist")]
        public async Task<IActionResult> GetStudentsAttendenceList([FromQuery] StudentListForAttendenceReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetStudentsAttendenceList(request);
            return Ok(response);
        }

        [HttpPost("saveteacherattendence")]
        public async Task<IActionResult> SaveTeachersAttendence([FromBody] SaveTeacherAttendenceReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HeaderHelper.GetHeaderValue(HttpContext.Request, "LoginUserId");
            var response = await _service.SaveTeachersAttendence(request, userId);
            return Ok(response);
        }

        [HttpGet("teacherattendencelist")]
        public async Task<IActionResult> GetTeachersAttendenceList()
        {
            var response = await _service.GetTeachersAttendenceList();
            return Ok(response);
        }
    }
}
