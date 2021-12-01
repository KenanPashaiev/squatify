using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserService.BL.Abstractions;
using UserService.BL.Models.User;
using UserService.BL.Utilities;
using UserService.Core;
using UserService.Core.Enums;
using UserService.DAL.Abstractions;

namespace UserService.BL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly PasswordHasher<object> passwordHasher;
        private readonly JwtService jwtService;

        public UserManager(IMapper mapper,
            PasswordHasher<object> passwordHasher,
            JwtService jwtService,
            IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.jwtService = jwtService;
            this.userRepository = userRepository;
        }

        public async Task<UserDto> GetUserAsync(Guid userId)
        {
            User user = await userRepository.GetUserAsync(userId);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            User user = await userRepository.GetUserByEmailAsync(email);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByNameCodeAsync(string username, string usercode)
        {
            User user = await userRepository.GetUserByNameCodeAsync(username, usercode);
            return mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await userRepository.GetAllUsersAsync();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var user = mapper.Map<User>(userRegisterDto);
            user.Password = passwordHasher.HashPassword(null, userRegisterDto.Password);
            user.Usercode = "0001";
            user.DateJoined = DateTime.UtcNow;
            
            if(userRegisterDto.Email == "admin@gmail.com")
            {
                user.Role = Role.Admin;
            }

            var addedUser = await userRepository.AddUserAsync(user);
            var addedUserDto = mapper.Map<UserDto>(addedUser);
            return addedUserDto;
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await userRepository.GetUserByEmailAsync(userLoginDto.Email);
            if(user == null)
            {
                return null;
            }

            var passwordVerificationResult =
                passwordHasher.VerifyHashedPassword(null, user.Password, userLoginDto.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var token = jwtService.GenerateToken(claims);

            return token;
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
        {
            var userPayload = mapper.Map<User>(userUpdateDto);
            var updatedUser = await userRepository.UpdateUserAsync(id, userPayload);
            return mapper.Map<UserDto>(updatedUser);
        }
    }
}