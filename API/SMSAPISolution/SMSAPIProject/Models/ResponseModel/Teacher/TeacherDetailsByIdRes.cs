using SMSAPIProject.Models.ResponseModel.Student;
using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.ResponseModel.Teacher
{
    public class TeacherDetailsByIdRes : CommonRes
    {
        public TeacherDetailsById? TeacherDetails { get; set; }
    }

    public class TeacherDetailsById
    {
        public int? Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Qualifications { get; set; }
        public int? ExperienceYears { get; set; }
        public string? Photo { get; set; }
        public bool? IsActive { get; set; }
    }
}
