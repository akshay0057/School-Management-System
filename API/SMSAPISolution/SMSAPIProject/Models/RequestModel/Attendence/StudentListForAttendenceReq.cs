using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class StudentListForAttendenceReq
    {
        [Required]
        public DateTime AttendenceDate { get; set; } = DateTime.Now;

        [Required]
        [SessionValidation]
        public string Session { get; set; } = string.Empty;

        [Required]
        public string FilterClass { get; set; } = string.Empty;

        public string FilterSection { get; set; } = string.Empty;
    }
}
