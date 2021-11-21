using System;
using UserService.Core.Enums;

namespace UserService.Core
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Usercode { get; set; }
        public Role Role { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
