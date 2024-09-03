namespace SMSAPIProject.Models.ResponseModel.Attendence
{
    public class TeacherListForAttendenceRes : CommonRes
    {
        public int TotalRecord { get; set; }
        public List<TeacherListForAttendenceData>? TeacherListForAttendence { get; set; }
    }

    public class TeacherListForAttendenceData
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public bool IsPresent { get; set; } = false;
        public bool IsAbsent { get; set; } = false;
        public bool IsHalfDayPresent { get; set; } = false;
        public bool IsLate { get; set; } = false;
        public bool IsOnLeave { get; set; } = false;
        public string? Remarks { get; set; }
    }
}
