using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExerciseVideoService.API.Services.Abstractions;
using ExerciseVideoService.BL.Managers;
using ExerciseVideoService.BL.Models.ExerciseSet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseVideoService.API
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseVideoController : ControllerBase
    {
        private readonly IExerciseSetManager exerciseSetManager;
        private readonly IUserService userService;

        public ExerciseVideoController(IExerciseSetManager exerciseSetManager, IUserService userService)
        {
            this.exerciseSetManager = exerciseSetManager;
            this.userService = userService;
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseVideoAsync([FromRoute]Guid id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if(role?.Value == "Client" && currentUserId == null)
            {
                return Unauthorized();
            }

            var exerciseSet = await exerciseSetManager.GetExerciseSetAsync(id);
            if(role?.Value == "Client" && currentUserId.Value != exerciseSet.UserId.ToString())
            {
                return Unauthorized();
            }

            return Ok(exerciseSet);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPost]
        public async Task<IActionResult> AddExerciseVideoAsync([FromBody]ExerciseVideoCreateDto exerciseVideoCreateDto)
        {
            var validLink = ExerciseVideoService.GetValidLink(exerciseVideoCreateDto.Link, )
            var response = trackingService.TrackVideo(exerciseVideoCreateDto.Link);


            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var exerciseSetUser = await userService.GetUserAsync(exerciseSetCreateUpdateDto.UserId);
            if(role == "Client" && currentUserId != exerciseSetUser.Id.ToString())
            {
                return Unauthorized();
            }

            var exerciseSetDto = await exerciseSetManager.AddExerciseSetAsync(exerciseSetCreateUpdateDto);
            return Ok(exerciseSetDto);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseVideoAsync(Guid id, ExerciseSetCreateUpdateDto exerciseSetCreateUpdateDto)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var exerciseSetUser = await userService.GetUserAsync(exerciseSetCreateUpdateDto.UserId);
            if(role == "Client" && currentUserId != exerciseSetUser.Id.ToString())
            {
                return Unauthorized();
            }

            var existingExerciseSet = await exerciseSetManager.GetExerciseSetAsync(id);
            if (existingExerciseSet == null)
            {
                return NotFound();
            }

            var users = await exerciseSetManager.UpdateExerciseSetAsync(id, exerciseSetCreateUpdateDto);
            return Ok(users);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseVideoAsync([FromRoute]Guid exerciseSetId)
        {
            var existingExerciseSet = await exerciseSetManager.GetExerciseSetAsync(exerciseSetId);
            if (existingExerciseSet == null)
            {
                return NotFound();
            }

            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var exerciseSetUser = await userService.GetUserAsync(existingExerciseSet.UserId);
            if(role == "Client" && currentUserId != exerciseSetUser.Id.ToString())
            {
                return Unauthorized();
            }

            var deletedExerciseSetId = await exerciseSetManager.DeleteExerciseSetAsync(existingExerciseSet.Id);
            return Ok(deletedExerciseSetId);
        }
    }
}
