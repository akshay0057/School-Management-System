using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class ParticularStudentAttendenceDetailsReq
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [SessionValidation]
        public string Session { get; set; } = string.Empty;

        [Required]
        public string Month { get; set; } = string.Empty;
    }
}
