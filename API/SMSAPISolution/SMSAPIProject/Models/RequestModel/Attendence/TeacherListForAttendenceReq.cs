using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class TeacherListForAttendenceReq
    {
        [Required]
        public DateTime AttendenceDate { get; set; } = DateTime.Now;
    }
}
