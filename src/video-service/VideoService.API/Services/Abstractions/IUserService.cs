using System.Threading.Tasks;
using VideoService.API.Services.Models;

namespace VideoService.API.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string id);
    }
}