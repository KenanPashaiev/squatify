using System;

namespace UserService.BL.Models.User
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}