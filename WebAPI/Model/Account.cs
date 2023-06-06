using System;
using System.Collections.Generic;

namespace WebAPI.Model
{
    public partial class Account
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
