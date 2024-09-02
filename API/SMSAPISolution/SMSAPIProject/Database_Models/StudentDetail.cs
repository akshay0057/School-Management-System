using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class StudentDetail
    {
        public int Id { get; set; }
        public string RollNo { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public int? GradeLevel { get; set; }
        public string Class { get; set; } = null!;
        public string Section { get; set; } = null!;
        public string? Photo { get; set; }
        public string? Note { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
