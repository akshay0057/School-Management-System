using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class MstSalutation
    {
        public int Id { get; set; }
        public string SalutationName { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
