namespace SMSAPIProject.Models.ResponseModel.Student
{
    public class StudentListRes: CommonRes
    {
        public int TotalRecords { get; set; }
        public List<StudentListData> StudentList { get; set; } = new List<StudentListData>();
    }

    public class StudentListData
    {
        public int Id { get; set; }
        public string RollNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
    }
}
