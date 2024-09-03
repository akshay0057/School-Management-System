namespace SMSAPIProject.Models.ResponseModel.Attendence
{
    public class StudentListForAttendenceRes : CommonRes
    {
        public int TotalRecord { get; set; }
        public List<StudentListForAttendenceData>? StudentListForAttendence { get; set; } 
    }

    public class StudentListForAttendenceData
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public bool IsPresent { get; set; } = false;
        public bool IsAbsent { get; set; } = false;
        public bool IsHalfDayPresent { get; set; } = false;
        public bool IsLate { get; set; } = false;
        public bool IsOnLeave { get; set; } = false;
        public string? Remarks { get; set; }
    }
}
