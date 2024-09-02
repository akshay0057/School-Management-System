namespace SMSAPIProject.Models.RequestModel.Student
{
    public class StudentListReq : PaginationReq
    {
        public string? FilterClass { get; set; }
        public string? FilterSection { get; set; }
    }
}
