using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Teacher
{
    public class AddUpdateTeacherReq
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime HireDate { get; set; }

        public string? Department { get; set; }

        [Required]
        public string? Position { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        public string? Qualifications { get; set; }

        [Required]
        public int? ExperienceYears { get; set; }

        public string? Photo { get; set; }

        public bool? IsActive { get; set; }
    }
}
