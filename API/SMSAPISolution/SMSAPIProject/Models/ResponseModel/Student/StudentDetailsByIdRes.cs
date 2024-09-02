namespace SMSAPIProject.Models.ResponseModel.Student
{
    public class StudentDetailsByIdRes : CommonRes
    {
        public StudentDetailsById? StudentDetails { get; set; }
    }

    public class StudentDetailsById
    {
        public int Id { get; set; }
        public string RollNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public int? GradeLevel { get; set; }
        public string Class { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string? Note { get; set; }
    }
}
