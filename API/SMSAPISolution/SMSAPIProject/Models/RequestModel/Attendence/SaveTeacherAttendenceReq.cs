namespace SMSAPIProject.Models.RequestModel.Attendence
{
    public class SaveTeacherAttendenceReq
    {
        public List<TeacherAttendenceRequestData>? AttendenceRequest { get; set; }
    }

    public class TeacherAttendenceRequestData
    {
        public int TeacherId { get; set; }
        public DateTime AttendenceDate { get; set; }
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
