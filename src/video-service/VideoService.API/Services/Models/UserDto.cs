using System;

namespace VideoService.API.Services.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Usercode { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
    }
}