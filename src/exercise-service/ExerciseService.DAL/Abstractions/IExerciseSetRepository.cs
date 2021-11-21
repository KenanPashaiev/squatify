using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseService.Core;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.DAL.Abstractions
{
    public interface IExerciseSetRepository
    {
        Task<ExerciseSet> GetAsync(Guid exerciseSetId);

        Task<IEnumerable<ExerciseSet>> GetByExerciseDayAsync(Guid userId, DateTime date);

        Task<IEnumerable<ExerciseSet>> GetByExerciseTypeAsync(Guid userId, Guid exerciseTypeId);

        Task<IEnumerable<ExerciseSet>> GetByExerciseTypeAsync(Guid userId, string exerciseTypeName);

        Task<ExerciseSet> AddAsync(ExerciseSet exerciseSet);

        Task<ExerciseSet> UpdateAsync(Guid exerciseSetId, ExerciseSet exerciseSet);

        Task<Guid> DeleteAsync(Guid exerciseSetId);
    }
}
