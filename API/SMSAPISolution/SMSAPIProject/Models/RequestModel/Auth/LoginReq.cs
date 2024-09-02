using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models.RequestModel.Auth
{
    public class LoginReq
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email field is required")]
        [EmailAddress(ErrorMessage = "Please enter correct email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
