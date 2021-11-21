using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseService.BL.Models.ExerciseSet;

namespace ExerciseService.BL.Managers
{
    public interface IExerciseSetManager
    {
        Task<ExerciseSetDto> GetExerciseSetAsync(Guid exerciseSetId);

        Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByDateRangeAsync(Guid userId, DateTime from, DateTime to);

        Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByExerciseTypeAsync(Guid userId, Guid exerciseTypeId);

        Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByExerciseTypeAsync(Guid userId, string exerciseTypeName);

        Task<ExerciseSetDto> AddExerciseSetAsync(ExerciseSetCreateUpdateDto exerciseSetDtoToAdd);

        Task<ExerciseSetDto> UpdateExerciseSetAsync(Guid id, ExerciseSetCreateUpdateDto exerciseSetDtoToUpdate);

        Task<Guid> DeleteExerciseSetAsync(Guid exerciseSetId);
    }
}
