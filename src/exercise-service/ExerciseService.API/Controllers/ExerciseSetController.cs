using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExerciseService.BL.Managers;
using ExerciseService.BL.Models.ExerciseSet;
using ExerciseService.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseService.API
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseSetController : ControllerBase
    {
        private readonly IExerciseSetManager exerciseSetManager;

        public ExerciseSetController(IExerciseSetManager exerciseSetManager)
        {
            this.exerciseSetManager = exerciseSetManager;
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseSetAsync([FromRoute]Guid id)
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
        
        [HttpGet("day")]
        public async Task<IActionResult> GetExerciseSetsByDayAsync([FromRoute]Guid userId, [FromRoute]DateTime day)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if(role?.Value == "Client" && (currentUserId == null || currentUserId?.Value != userId.ToString()))
            {
                return Unauthorized();
            }

            var exerciseSets = await exerciseSetManager.GetExerciseSetByExerciseDayAsync(userId, day);
            return Ok(exerciseSets);
        }

        [HttpPost]
        public async Task<IActionResult> AddExerciseSetAsync([FromBody]ExerciseSetCreateUpdateDto exerciseSetCreateUpdateDto)
        {
            var exerciseSetDto = await exerciseSetManager.AddExerciseSetAsync(exerciseSetCreateUpdateDto);
            return Ok(exerciseSetDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, ExerciseSetCreateUpdateDto exerciseSetCreateUpdateDto)
        {
            var existingExerciseSet = await exerciseSetManager.GetExerciseSetAsync(id);
            if (existingExerciseSet == null)
            {
                return NotFound();
            }

            var users = await exerciseSetManager.UpdateExerciseSetAsync(id, exerciseSetCreateUpdateDto);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid exerciseSetId)
        {
            var deletedExerciseSetId = await exerciseSetManager.DeleteExerciseSetAsync(exerciseSetId);
            return Ok(deletedExerciseSetId);
        }
    }
}
