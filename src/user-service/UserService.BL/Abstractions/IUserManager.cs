using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.BL.Models.User;

namespace UserService.BL.Abstractions
{
    public interface IUserManager
    {
        Task<UserDto> GetUserAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<UserDto> GetUserByNameCodeAsync(string username, string usercode);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userRegisterDto);
        Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    }
}