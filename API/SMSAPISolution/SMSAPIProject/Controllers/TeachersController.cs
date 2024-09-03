using Microsoft.AspNetCore.Mvc;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Helper;
using SMSAPIProject.Models.RequestModel;
using SMSAPIProject.Models.RequestModel.Teacher;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeachersController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet("teacherlist")]
        public async Task<IActionResult> GetTeacherList([FromQuery] PaginationReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetTeacherList(request);
            return Ok(response);
        }

        [HttpGet("teacherbyid")]
        public async Task<IActionResult> GetTeacherDetailsById([FromQuery] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetTeacherDetailsById(Id);
            return Ok(response);
        }

        [HttpPost("addupdateteacher")]
        public async Task<ActionResult<StudentDetail>> AddUpdateTeacher([FromBody] AddUpdateTeacherReq request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HeaderHelper.GetHeaderValue(HttpContext.Request, "LoginUserId");
            var response = await _service.AddUpdateTeacher(request, userId);
            return Ok(response);
        }

        [HttpDelete("deleteteacher")]
        public async Task<IActionResult> DeleteTeacherById([FromQuery] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.DeleteTeacherById(Id);
            return Ok(response);
        }
    }
}
