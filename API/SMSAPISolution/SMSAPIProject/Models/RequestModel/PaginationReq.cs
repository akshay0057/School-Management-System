namespace SMSAPIProject.Models.RequestModel
{
    public class PaginationReq
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string SearchText { get; set; } = string.Empty;
    }
}
