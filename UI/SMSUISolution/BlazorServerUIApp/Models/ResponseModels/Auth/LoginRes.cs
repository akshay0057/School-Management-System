namespace BlazorServerUIApp.Models.ResponseModels.Auth
{
    public class LoginRes : CommonRes
    {
        public LoginResponseData? Data { get; set; }
    }

    public class LoginResponseData
    {
        public string UserId { get; set; } = null!;
        public int? RoleId { get; set; }
        public int SalutationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }
}
