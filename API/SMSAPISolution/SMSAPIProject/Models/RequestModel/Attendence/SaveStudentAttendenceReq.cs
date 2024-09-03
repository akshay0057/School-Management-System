using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class SaveStudentAttendenceReq
    {
        [Required]
        [RequestTypeValidation]
        public string RequestType { get; set; } = string.Empty;

        [Required]
        [SessionValidation]
        public string Session { get; set; } = string.Empty;

        [Required]
        public List<StudentAttendenceRequestData>? AttendenceRequest { get; set; }
    }

    public class StudentAttendenceRequestData
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public DateTime AttendenceDate { get; set; }
        public bool IsPresent { get; set; } = false;
        public bool IsAbsent { get; set; } = false;
        public bool IsHalfDayPresent { get; set; } = false;
        public bool IsLate { get; set; } = false;
        public bool IsOnLeave { get; set; } = false;
        public string? Remarks { get; set; }
    }
}
