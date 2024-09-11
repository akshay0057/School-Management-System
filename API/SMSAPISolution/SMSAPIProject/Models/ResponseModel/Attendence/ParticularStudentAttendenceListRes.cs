namespace SMSAPIProject.Models.ResponseModel.Attendence
{
    public class ParticularStudentAttendenceListRes : CommonRes
    {
        public int ToTalRecords { get; set; }
        public List<ParticularStudentAttendenceListData>? Data { get; set; }
    }

    public class ParticularStudentAttendenceListData
    {
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
