using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class TeacherAttendenceDetail
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public DateTime AttendenceDate { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsAbsent { get; set; }
        public bool? IsHalfDayPresent { get; set; }
        public bool? IsLate { get; set; }
        public bool? IsOnLeave { get; set; }
        public string? Remarks { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual TeacherDetail Teacher { get; set; } = null!;
    }
}
