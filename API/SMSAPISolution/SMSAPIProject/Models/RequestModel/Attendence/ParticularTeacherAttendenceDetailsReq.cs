using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class ParticularTeacherAttendenceDetailsReq
    {
        [Required]
        public int TeacherId { get; set; }

        [Required]
        public string Month { get; set; } = string.Empty;
    }
}
