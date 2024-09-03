using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class TeacherDetail
    {
        public TeacherDetail()
        {
            TeacherAttendenceDetails = new HashSet<TeacherAttendenceDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Qualifications { get; set; }
        public int? ExperienceYears { get; set; }
        public string? Photo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<TeacherAttendenceDetail> TeacherAttendenceDetails { get; set; }
    }
}
