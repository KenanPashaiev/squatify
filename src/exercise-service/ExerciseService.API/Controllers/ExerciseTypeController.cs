using System;
using System.Threading.Tasks;
using ExerciseService.BL.Managers;
using ExerciseService.BL.Models.ExerciseType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseService.API
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IExerciseTypeManager exerciseTypeManager;

        public ExerciseTypeController(IExerciseTypeManager exerciseTypeManager)
        {
            this.exerciseTypeManager = exerciseTypeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseTypeAsync([FromRoute]Guid id)
        {
            var exerciseType = await exerciseTypeManager.GetExerciseTypeAsync(id);
            return Ok(exerciseType);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllExerciseTypesAsync()
        {
            var exerciseTypes = await exerciseTypeManager.GetAllExerciseTypesAsync();
            return Ok(exerciseTypes);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddExerciseTypeAsync([FromBody]ExerciseTypeCreateUpdateDto exerciseTypeCreateUpdateDto)
        {
            var exerciseTypeDto = await exerciseTypeManager.AddExerciseTypeAsync(exerciseTypeCreateUpdateDto);
            return Ok(exerciseTypeDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, ExerciseTypeCreateUpdateDto exerciseTypeCreateUpdateDto)
        {
            var existingExerciseType = await exerciseTypeManager.GetExerciseTypeAsync(id);
            if (existingExerciseType == null)
            {
                return NotFound();
            }

            var users = await exerciseTypeManager.UpdateExerciseTypeAsync(id, exerciseTypeCreateUpdateDto);
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var deletedExerciseTypeId = await exerciseTypeManager.DeleteExerciseTypeAsync(id);
            return Ok(deletedExerciseTypeId);
        }
    }
}
