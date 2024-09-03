using SMSAPIProject.Models.RequestModel;
using SMSAPIProject.Models.RequestModel.Teacher;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Teacher;

namespace SMSAPIProject.Services.IServices
{
    public interface ITeacherService
    {
        public Task<CommonRes> AddUpdateTeacher(AddUpdateTeacherReq request, string loginUserId);
        public Task<CommonRes> DeleteTeacherById(int id);
        public Task<TeacherDetailsByIdRes> GetTeacherDetailsById(int id);
        public Task<TeacherListRes> GetTeacherList(PaginationReq request);
    }
}
