using System;
using System.Collections.Generic;

namespace SMSAPIProject.Database_Models
{
    public partial class MstClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
