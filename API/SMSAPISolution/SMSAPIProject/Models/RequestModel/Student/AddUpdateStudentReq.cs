using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Student
{
    public class AddUpdateStudentReq
    {
        public int? Id { get; set; }

        public string RollNo { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        public string? Email { get; set; }

        [Required]
        [MaxLength(10)]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public int? GradeLevel { get; set; }

        [Required]
        public string Class { get; set; } = string.Empty;

        [Required]
        public string Section { get; set; } = string.Empty;

        public string? Photo { get; set; }

        public string? Note { get; set; }
    }
}
