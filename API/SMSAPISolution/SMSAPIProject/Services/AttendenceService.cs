using Microsoft.EntityFrameworkCore;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Models.Enum;
using SMSAPIProject.Models.RequestModel.Attendence;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Attendence;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Services
{
    public class AttendenceService : IAttendenceService
    {
        private readonly SMS_Dev_DbContext _context;
        public AttendenceService(SMS_Dev_DbContext context)
        {
            _context = context;
        }

        public async Task<StudentListForAttendenceRes> GetStudentsAttendenceList(StudentListForAttendenceReq request)
        {
            try
            {
                var response = new StudentListForAttendenceRes();
                var studentList = new List<StudentListForAttendenceData>();

                // Validate filterclass
                if (string.IsNullOrEmpty(request.FilterClass)) 
                {
                    response.Status = false;
                    response.Message = "Invalid request";
                    return response;
                }

                var attendenceDetails = await _context.StudentAttendenceDetails.Where(x => x.AttendenceDate.Date == request.AttendenceDate.Date && x.AttendenceDate.Month == request.AttendenceDate.Month && x.AttendenceDate.Year == request.AttendenceDate.Year).ToListAsync();
                if (!attendenceDetails.Any())
                {
                    var students = await _context.StudentDetails.Where(x => x.Session == request.Session.Trim() && x.Class == request.FilterClass.Trim()).ToListAsync();

                    // Check for section
                    if (!string.IsNullOrEmpty(request.FilterSection))
                    {
                        students = students.Where(x => x.Section == request.FilterSection.Trim()).ToList();
                    }

                    studentList = students.OrderBy(x => x.RollNo)
                        .Select(y => new StudentListForAttendenceData()
                        {
                            StudentId = y.Id,
                            StudentName = (y.FirstName + " " + (y.LastName ?? "")).Trim(),
                            IsPresent = false,
                            IsAbsent = false,
                            IsHalfDayPresent = false,
                            IsLate = false,
                            IsOnLeave = false,
                            Remarks = ""
                        }).ToList();
                }
                else
                {
                    studentList = (from ad in attendenceDetails
                                   join sd in _context.StudentDetails on ad.StudentId equals sd.Id
                                   select new StudentListForAttendenceData()
                                   {
                                       StudentId = ad.Id,
                                       StudentName = (sd.FirstName + " " + (sd.LastName ?? "")).Trim(),
                                       IsPresent = ad.IsPresent ?? false,
                                       IsAbsent = ad.IsAbsent ?? false,
                                       IsHalfDayPresent = ad.IsHalfDayPresent ?? false,
                                       IsLate = ad.IsLate ?? false,
                                       IsOnLeave = ad.IsOnLeave ?? false,
                                       Remarks = ad.Remarks
                                   }).ToList();
                }

                response.Status = true;
                response.Message = "Success";
                response.TotalRecord = studentList.Count();
                response.StudentListForAttendence = studentList;
                return response;
            }
            catch (Exception ex)
            {
                return new StudentListForAttendenceRes()
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

        public async Task<TeacherListForAttendenceRes> GetTeachersAttendenceList()
        {
            try
            {
                var response = new TeacherListForAttendenceRes();

                var teachers = await _context.TeacherDetails
                    .Select(x => new TeacherListForAttendenceData()
                    {
                        TeacherId = x.Id,
                        TeacherName = (x.FirstName + " " + (x.LastName ?? "")).Trim()
                    }).OrderBy(y => y.TeacherName)
                    .ToListAsync();

                response.Status = true;
                response.Message = "Success";
                response.TotalRecord = teachers.Count();
                response.TeacherListForAttendence = teachers;
                return response;
            }
            catch (Exception ex)
            {
                return new TeacherListForAttendenceRes()
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

        public async Task<CommonRes> SaveStudentsAttendence(SaveStudentAttendenceReq request, string loginUserId)
        {
            try
            {
                var response = new CommonRes();

                if (request.AttendenceRequest != null && request.AttendenceRequest.Count() > 0)
                {
                    // SAVE
                    if (request.RequestType == SaveUpdateRequestType.Save.ToString())
                    {
                        var data = new List<StudentAttendenceDetail>();
                        foreach (var item in request.AttendenceRequest)
                        {
                            data.Add(new StudentAttendenceDetail()
                            {
                                StudentId = item.StudentId,
                                AttendenceDate = item.AttendenceDate,
                                IsPresent = item.IsPresent,
                                IsAbsent = item.IsAbsent,
                                IsHalfDayPresent = item.IsHalfDayPresent,
                                IsLate = item.IsLate,
                                IsOnLeave = item.IsOnLeave,
                                Remarks = item.Remarks,
                                Session = request.Session,
                                CreatedBy = loginUserId,
                                CreatedOn = DateTime.Now
                            });
                        }
                        await _context.StudentAttendenceDetails.AddRangeAsync(data);
                        await _context.SaveChangesAsync();

                        response.Status = true;
                        response.Message = "Attendence data save successfully";
                        return response;
                    }

                    // UPDATE
                    var attendenceDetails = await _context.StudentAttendenceDetails.Where(x => x.Session == request.Session).ToListAsync();
                    foreach(var item in request.AttendenceRequest)
                    {
                        var attendence = attendenceDetails.Find(x => x.Id == item.Id);
                        if (attendence != null)
                        {
                            attendence.IsPresent = item.IsPresent;
                            attendence.IsAbsent = item.IsAbsent;
                            attendence.IsHalfDayPresent = item.IsHalfDayPresent;
                            attendence.IsLate = item.IsLate;
                            attendence.IsOnLeave = item.IsOnLeave;
                            attendence.Remarks = item.Remarks;
                            attendence.ModifiedBy = loginUserId;
                            attendence.ModifiedOn = DateTime.Now;
                        }
                    }
                    await _context.SaveChangesAsync();
                    response.Status = true;
                    response.Message = "Attendence data updated successfully";
                    return response;
                }

                response.Status = false;
                response.Message = "Invalid request";
                return response;
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

        public async Task<CommonRes> SaveTeachersAttendence(SaveTeacherAttendenceReq request, string loginUserId)
        {
            try
            {
                return new CommonRes();
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
    }
}
