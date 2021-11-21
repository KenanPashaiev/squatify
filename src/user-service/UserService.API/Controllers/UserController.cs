using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.BL.Abstractions;
using UserService.BL.Models.User;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync([FromRoute]Guid id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (role?.Value == "Client" && (currentUserId == null || currentUserId.Value != id.ToString()))
            {
                return Unauthorized();
            }

            var user = await userManager.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await userManager.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var users = await userManager.RegisterAsync(userRegisterDto);
            return Ok(users);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLoginDto userLoginDto)
        {
            var token = await userManager.LoginAsync(userLoginDto);
            if(token == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                token,
                userLoginDto.Email
            });
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "NameIdentifier");
            if (currentUserId == null || currentUserId.Value != id.ToString())
            {
                return Unauthorized();
            }

            var existingUser = await userManager.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var users = await userManager.UpdateUserAsync(id, userUpdateDto);
            return Ok(users);
        }
    }
}
