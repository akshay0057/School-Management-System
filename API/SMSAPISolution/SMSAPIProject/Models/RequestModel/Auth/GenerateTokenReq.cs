namespace SMSAPIProject.Models.RequestModel.Auth
{
    public class GenerateTokenReq
    {
        public string UserId { get; set; } = string.Empty;
        public int? RoleId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public DateTime? ExpiaryDateTime { get; set; }
    }
}
