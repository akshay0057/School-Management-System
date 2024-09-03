namespace SMSAPIProject.Models.ResponseModel.Teacher
{
    public class TeacherListRes : CommonRes
    {
        public int TotalRecords { get; set; }
        public List<TeacherListData> TeacherList { get; set; } = new List<TeacherListData>();
    }

    public class TeacherListData
    {
        public int Id { get; set; } 
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
