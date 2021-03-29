using NorthWnd.CORE.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace NorthWnd.CORE.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
