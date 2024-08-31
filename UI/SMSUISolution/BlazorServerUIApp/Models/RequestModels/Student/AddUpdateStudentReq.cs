using System.ComponentModel.DataAnnotations;

namespace BlazorServerUIApp.Models.RequestModels.Student
{
    public class AddUpdateStudentReq
    {
        public int? StudentId { get; set; }

        public string? RollNo { get; set; }

        [Required(ErrorMessage = "First Name field is required")]
        [MaxLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please select DOB")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        [MaxLength(10, ErrorMessage = "Gender can't be longer than 10 characters")]
        public string Gender { get; set; } = string.Empty;

        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(250, ErrorMessage = "Address can't be longer than 250 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int? GradeLevel { get; set; }

        [Required(ErrorMessage = "Please select Class")]
        [MaxLength(100, ErrorMessage = "Class can't be longer than 100 characters")]
        public string Class { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select Section")]
        [MaxLength(50, ErrorMessage = "Section can't be longer than 50 characters")]
        public string Section { get; set; } = string.Empty;

        public byte[]? Photo { get; set; }

        public string? Notes { get; set; }
    }
}
