using SMSAPIProject.Models.RequestModel.Student;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Student;

namespace SMSAPIProject.Services.IServices
{
    public interface IStudentService
    {
        public Task<CommonRes> AddUpdateStudent(AddUpdateStudentReq request, string loginUserId);
        public Task<CommonRes> DeleteStudentById(int id);
        public Task<StudentDetailsByIdRes> GetStudentDetailsById(int id);
        public Task<StudentListRes> GetStudentList(StudentListReq request);
    }
}
