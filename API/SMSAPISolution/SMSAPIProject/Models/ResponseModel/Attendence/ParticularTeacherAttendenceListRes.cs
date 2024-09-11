namespace SMSAPIProject.Models.ResponseModel.Attendence
{
    public class ParticularTeacherAttendenceListRes : CommonRes
    {
        public int ToTalRecords { get; set; }
        public List<ParticularTeacherAttendenceListData>? Data { get; set; }
    }

    public class ParticularTeacherAttendenceListData
    {
        public DateTime Date { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
