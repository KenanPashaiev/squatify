using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseService.BL.Models.ExerciseType;

namespace ExerciseService.BL.Managers
{
    public interface IExerciseTypeManager
    {
        Task<ExerciseTypeDto> GetExerciseTypeAsync(Guid exerciseTypeId);

        Task<ExerciseTypeDto> GetExerciseTypeByNameAsync(string name);

        Task<IEnumerable<ExerciseTypeDto>> GetAllExerciseTypesAsync();

        Task<ExerciseTypeDto> AddExerciseTypeAsync(ExerciseTypeCreateUpdateDto exerciseTypeDtoToAdd);

        Task<ExerciseTypeDto> UpdateExerciseTypeAsync(Guid exerciseTypeId, ExerciseTypeCreateUpdateDto exerciseTypeDtoToUpdate);

        Task<Guid> DeleteExerciseTypeAsync(Guid exerciseTypeId);
    }
}
