namespace SMSAPIProject.Models.ResponseModel
{
    public class CommonRes
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public ErrorModel? Error { get; set; }   
    }

    public class ErrorModel
    {
        public string StatusCode { get; set; } = string.Empty;
        public string ErrorDescryption { get; set; } = string.Empty;
    }
}
