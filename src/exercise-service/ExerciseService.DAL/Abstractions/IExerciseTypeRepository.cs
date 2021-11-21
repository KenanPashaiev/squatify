using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseService.Core;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.DAL.Abstractions
{
    public interface IExerciseTypeRepository
    {
        Task<ExerciseType> GetAsync(Guid exerciseTypeId);

        Task<ExerciseType> GetByNameAsync(string name);

        Task<IEnumerable<ExerciseType>> GetAllAsync();

        Task<ExerciseType> AddAsync(ExerciseType exerciseType);

        Task<ExerciseType> UpdateAsync(Guid exerciseTypeId, ExerciseType exerciseType);

        Task<Guid> DeleteAsync(Guid exerciseTypeId);
    }
}
