using System;
using System.Collections.Generic;

namespace SE310_28102024.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public int? Role { get; set; }
    }
}
