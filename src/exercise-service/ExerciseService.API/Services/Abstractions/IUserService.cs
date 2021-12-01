using System;
using System.Threading.Tasks;
using ExerciseService.API.Services.Models;

namespace ExerciseService.API.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(Guid id);
    }
}