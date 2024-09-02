using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int? RoleId { get; set; }
        public int SalutationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Photo { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
