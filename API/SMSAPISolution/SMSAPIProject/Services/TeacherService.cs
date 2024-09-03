using SMSAPIProject.Database_Models;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.RequestModel.Teacher;
using Microsoft.EntityFrameworkCore;
using SMSAPIProject.Models.ResponseModel.Teacher;
using SMSAPIProject.Models.RequestModel;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly SMS_Dev_DbContext _context;
        public TeacherService(SMS_Dev_DbContext context)
        {
            _context = context;
        }

        public async Task<CommonRes> AddUpdateTeacher(AddUpdateTeacherReq request, string loginUserId)
        {
            try
            {
                // Creation
                if (request.Id == null || request.Id == 0)
                {
                    var lastTeacherDtl = await _context.TeacherDetails.OrderByDescending(y => y.Id).FirstOrDefaultAsync();

                    // Creating request for saving
                    var data = new TeacherDetail()
                    {
                        FirstName = request.FirstName.Trim(),
                        LastName = request.LastName?.Trim(),
                        Gender = request.Gender.Trim(),
                        DateOfBirth = request.DateOfBirth,
                        Email = request.Email.Trim(),
                        Phone = request.Phone.Trim(),
                        Address = request.Address.Trim(),
                        HireDate = request.HireDate,
                        Department = request.Department,
                        Position = request.Position?.Trim(),
                        Salary = request.Salary,
                        Qualifications = request.Qualifications,
                        ExperienceYears = request.ExperienceYears,
                        Photo = request.Photo,
                        IsActive = request.IsActive,
                        CreatedBy = loginUserId,
                        CreatedOn = DateTime.Now
                    };

                    await _context.TeacherDetails.AddAsync(data);
                    await _context.SaveChangesAsync();
                    return new CommonRes()
                    {
                        Status = true,
                        Message = "Teacher added successfully"
                    };
                }

                // Updation
                var teacherDtl = await _context.TeacherDetails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (teacherDtl == null)
                {
                    return new CommonRes() { Status = false, Message = "Student details not found" };
                }
                teacherDtl.FirstName = request.FirstName.Trim();
                teacherDtl.LastName = request.LastName?.Trim();
                teacherDtl.Gender = request.Gender.Trim();
                teacherDtl.DateOfBirth = request.DateOfBirth;
                teacherDtl.Email = request.Email.Trim();
                teacherDtl.Phone = request.Phone.Trim();
                teacherDtl.Address = request.Address.Trim();
                teacherDtl.HireDate = request.HireDate;
                teacherDtl.Department = request.Department;
                teacherDtl.Position = request.Position?.Trim();
                teacherDtl.Salary = request.Salary;
                teacherDtl.Qualifications = request.Qualifications;
                teacherDtl.ExperienceYears = request.ExperienceYears;
                teacherDtl.Photo = request.Photo;
                teacherDtl.IsActive = request.IsActive;
                teacherDtl.ModifiedBy = loginUserId;
                teacherDtl.ModifiedOn = DateTime.Now;

                _context.TeacherDetails.Update(teacherDtl);
                await _context.SaveChangesAsync();
                return new CommonRes()
                {
                    Status = true,
                    Message = "Teacher updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonRes()
                {
                    Status = false,
                    Message = "Error",
                    Error = new ErrorModel()
                    {
                        StatusCode = "400",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }

        public async Task<CommonRes> DeleteTeacherById(int id)
        {
            try
            {
                var teacherDtl = await _context.TeacherDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (teacherDtl == null)
                {
                    return new CommonRes() { Status = false, Message = "Teacher details not found" };
                }

                _context.TeacherDetails.Remove(teacherDtl);
                await _context.SaveChangesAsync();
                return new CommonRes()
                {
                    Status = true,
                    Message = "Teacher deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new CommonRes()
                {
                    Status = false,
                    Message = "Error",
                    Error = new ErrorModel()
                    {
                        StatusCode = "400",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }

        public async Task<TeacherDetailsByIdRes> GetTeacherDetailsById(int id)
        {
            try
            {
                var teacherDtl = await _context.TeacherDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (teacherDtl == null)
                {
                    return new TeacherDetailsByIdRes() { Status = false, Message = "Teacher details not found" };
                }

                var response = new TeacherDetailsByIdRes();
                response.Status = true;
                response.Message = "Success";
                response.TeacherDetails = new TeacherDetailsById()
                {
                    Id = id,
                    FirstName = teacherDtl.FirstName,
                    LastName = teacherDtl.LastName,
                    Gender = teacherDtl.Gender,
                    DateOfBirth = teacherDtl.DateOfBirth,
                    Email = teacherDtl.Email,
                    Phone = teacherDtl.Phone,
                    Address = teacherDtl.Address,
                    HireDate = teacherDtl.HireDate,
                    Department = teacherDtl.Department,
                    Position = teacherDtl.Position,
                    Salary = teacherDtl.Salary,
                    Qualifications = teacherDtl.Qualifications,
                    ExperienceYears = teacherDtl.ExperienceYears,
                    Photo = teacherDtl.Photo,
                    IsActive = teacherDtl.IsActive
                };

                return response;
            }
            catch (Exception ex)
            {
                return new TeacherDetailsByIdRes()
                {
                    Status = false,
                    Message = "Error",
                    Error = new ErrorModel()
                    {
                        StatusCode = "400",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }

        public async Task<TeacherListRes> GetTeacherList(PaginationReq request)
        {
            try
            {
                var teachers = await _context.TeacherDetails
                    .OrderBy(x => (x.FirstName + " " + (x.LastName??"")).Trim())
                    .Select(y => new TeacherListData()
                    {
                        Id = y.Id,
                        FullName = (y.FirstName + " " + (y.LastName ?? "")).Trim(),
                        Email = y.Email,
                        Phone = y.Phone,
                        HireDate = y.HireDate
                    }).ToListAsync();

                if (!teachers.Any())
                {
                    return new TeacherListRes() { Status = false, Message = "No Teacher found" };
                }

                // Searching
                if (!string.IsNullOrEmpty(request.SearchText))
                {
                    teachers = teachers.Where(x =>
                        x.FullName.ToLower().Trim().Contains(request.SearchText.ToLower().Trim()) ||
                        x.Email.ToLower().Trim().Contains(request.SearchText.ToLower().Trim()) ||
                        x.Phone.ToLower().Trim().Contains(request.SearchText.ToLower().Trim()) || 
                        x.HireDate.ToString("dd MM yyyy").ToLower().Trim().Contains(request.SearchText.ToLower().Trim())
                    ).ToList();
                }

                // Pagination
                var data = teachers.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

                return new TeacherListRes()
                {
                    Status = true,
                    Message = "Success",
                    TotalRecords = teachers.Count(),
                    TeacherList = data
                };
            }
            catch (Exception ex)
            {
                return new TeacherListRes()
                {
                    Status = false,
                    Message = "Error",
                    Error = new ErrorModel()
                    {
                        StatusCode = "400",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }
    }
}
