using UserService.Core.Enums;

namespace UserService.BL.Models.User
{
    public class UserUpdateDto
    {
        public string Username { get; set; }
        public string Usercode { get; set; }
        public Role Role { get; set; }
    }
}