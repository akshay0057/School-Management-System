using SMSAPIProject.Models.RequestModel.Attendence;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Attendence;

namespace SMSAPIProject.Services.IServices
{
    public interface IAttendenceService
    {
        public Task<CommonRes> SaveStudentsAttendence(SaveStudentAttendenceReq request, string loginUserId);
        public Task<StudentListForAttendenceRes> GetStudentsAttendenceList(StudentListForAttendenceReq request);
        public Task<CommonRes> SaveTeachersAttendence(SaveTeacherAttendenceReq request, string loginUserId);
        public Task<TeacherListForAttendenceRes> GetTeachersAttendenceList();
    }
}
