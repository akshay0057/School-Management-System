using Microsoft.EntityFrameworkCore;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Models.RequestModel.Student;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Student;
using SMSAPIProject.Services.IServices;
using SMSAPIProject.Helper;

namespace SMSAPIProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMS_Dev_DbContext _context;
        public StudentService(SMS_Dev_DbContext context)
        {
            _context = context;
        }

        public async Task<CommonRes> AddUpdateStudent(AddUpdateStudentReq request, string loginUserId)
        {
            try
            {
                // Creation
                if(request.Id == null || request.Id == 0)
                {
                    var lastStudentDtl = await _context.StudentDetails.Where(x => x.Class.ToLower().Trim() == request.Class.ToLower().Trim() && x.Section.ToLower().Trim() == request.Section.ToLower().Trim())
                        .OrderByDescending(y => y.Id).FirstOrDefaultAsync();

                    // Creating new roll no
                    string rollNo = string.Empty;
                    if(lastStudentDtl == null) // Means first student for this class and for this section
                    {
                        rollNo = GenerateIdHelper.GenerateNewRollNo(string.Empty);
                    }
                    else
                    {
                        rollNo = GenerateIdHelper.GenerateNewRollNo(lastStudentDtl.RollNo.Trim());
                    }

                    // Creating request for saving
                    var data = new StudentDetail()
                    {
                        RollNo = rollNo,
                        FirstName = request.FirstName.Trim(),
                        LastName = request.LastName?.Trim(),
                        DateOfBirth = request.DateOfBirth,
                        Gender = request.Gender.Trim(),
                        Email = request.Email?.Trim(),
                        Phone = request.Phone.Trim(),
                        Address = request.Address.Trim(),
                        EnrollmentDate = request.EnrollmentDate,
                        GradeLevel = request.GradeLevel,
                        Class = request.Class.Trim(),
                        Section = request.Section.Trim(),
                        Photo = request.Photo,
                        Note = request.Note?.Trim(),
                        CreatedBy = loginUserId,
                        CreatedOn = DateTime.Now
                    };

                    await _context.StudentDetails.AddAsync(data);
                    await _context.SaveChangesAsync();
                    return new CommonRes()
                    {
                        Status = true,
                        Message = "Student added successfully"
                    };
                }

                // Updation
                var studentDtl = await _context.StudentDetails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (studentDtl == null)
                {
                    return new CommonRes() { Status = false, Message = "Student details not found" };
                }
                studentDtl.FirstName = request.FirstName.Trim();
                studentDtl.LastName = request.LastName?.Trim();
                studentDtl.DateOfBirth = request.DateOfBirth;
                studentDtl.Gender = request.Gender.Trim();
                studentDtl.Email = request.Email?.Trim();
                studentDtl.Phone = request.Phone.Trim();
                studentDtl.Address = request.Address.Trim();
                studentDtl.EnrollmentDate = request.EnrollmentDate;
                studentDtl.GradeLevel = request.GradeLevel;
                studentDtl.Class = request.Class.Trim();
                studentDtl.Section = request.Section.Trim();
                studentDtl.Photo = request.Photo;
                studentDtl.Note = request.Note?.Trim();
                studentDtl.ModifiedBy = loginUserId;
                studentDtl.ModifiedOn = DateTime.Now;

                _context.StudentDetails.Update(studentDtl);
                await _context.SaveChangesAsync();
                return new CommonRes()
                {
                    Status = true,
                    Message = "Student updated successfully"
                };
            }
            catch(Exception ex)
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

        public async Task<CommonRes> DeleteStudentById(int id)
        {
            try
            {
                var studentDtl = await _context.StudentDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (studentDtl == null)
                {
                    return new CommonRes() { Status = false, Message = "Student details not found" };
                }

                _context.StudentDetails.Remove(studentDtl);
                await _context.SaveChangesAsync();
                return new CommonRes()
                {
                    Status = true,
                    Message = "Student deleted successfully"
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

        public async Task<StudentDetailsByIdRes> GetStudentDetailsById(int id)
        {
            try
            {
                var studentDtl = await _context.StudentDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (studentDtl == null)
                {
                    return new StudentDetailsByIdRes() { Status = false, Message = "Student details not found" };
                }

                var response = new StudentDetailsByIdRes();
                response.Status = true;
                response.Message = "Success";
                response.StudentDetails = new StudentDetailsById()
                {
                    Id = id,
                    RollNo = studentDtl.RollNo,
                    FirstName = studentDtl.FirstName,
                    LastName = studentDtl.LastName,
                    DateOfBirth = studentDtl.DateOfBirth,
                    Gender = studentDtl.Gender,
                    Email = studentDtl.Email,
                    Phone = studentDtl.Phone,
                    Address = studentDtl.Address,
                    EnrollmentDate = studentDtl.EnrollmentDate,
                    GradeLevel = studentDtl.GradeLevel,
                    Class = studentDtl.Class,
                    Section = studentDtl.Section,
                    Photo = studentDtl.Photo,
                    Note = studentDtl.Note
                };

                return response;
            }
            catch (Exception ex)
            {
                return new StudentDetailsByIdRes()
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

        public async Task<StudentListRes> GetStudentList(StudentListReq request)
        {
            try
            {
                var students = await _context.StudentDetails
                    .OrderBy(x => x.RollNo)
                    .Select(y => new StudentListData()
                    {
                        Id = y.Id,
                        RollNo = y.RollNo,
                        FullName = (y.FirstName + " " + (y.LastName??"")).Trim(),
                        Class = y.Class,
                        Section = y.Section
                    }).ToListAsync();
                if(!students.Any())
                {
                    return new StudentListRes() { Status = false, Message = "No Student found" };
                }

                // Searching
                if(!string.IsNullOrEmpty(request.SearchText))
                {
                    students = students.Where(x => 
                        x.RollNo.Contains(request.SearchText.Trim()) ||
                        x.FullName.ToLower().Trim().Contains(request.SearchText.ToLower().Trim()) ||
                        x.Class.ToLower().Trim().Contains(request.SearchText.ToLower().Trim()) || 
                        x.Section.ToLower().Trim().Contains(request.SearchText.ToLower().Trim())
                    ).ToList();
                }

                // Filter
                if(!string.IsNullOrEmpty(request.FilterClass))
                {
                    students = students.Where(x => x.Class.ToLower().Trim() == request.FilterClass.ToLower().Trim()).ToList();
                }
                if (!string.IsNullOrEmpty(request.FilterSection))
                {
                    students = students.Where(x => x.Section.ToLower().Trim() == request.FilterSection.ToLower().Trim()).ToList();
                }

                // Pagination
                var data = students.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

                return new StudentListRes()
                {
                    Status = true,
                    Message = "Success",
                    TotalRecords = students.Count(),
                    StudentList = data
                };
            }
            catch (Exception ex)
            {
                return new StudentListRes()
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
