using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseService.Core;
using ExerciseService.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.DAL.Repositories
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly ExerciseContext exerciseContext;

        public ExerciseTypeRepository(ExerciseContext exerciseContext)
        {
            this.exerciseContext = exerciseContext;
        }

        public Task<ExerciseType> GetAsync(Guid exerciseTypeId)
        {
            return exerciseContext.ExerciseTypes
                .SingleOrDefaultAsync(et => et.Id == exerciseTypeId);
        }

        public Task<ExerciseType> GetByNameAsync(string name)
        {
            return exerciseContext.ExerciseTypes
                .SingleOrDefaultAsync(et => et.Name == name);
        }

        public async Task<IEnumerable<ExerciseType>> GetAllAsync()
        {
            return await exerciseContext.ExerciseTypes.ToListAsync();
        }

        public async Task<ExerciseType> AddAsync(ExerciseType exerciseType)
        {
            var entity = exerciseContext.ExerciseTypes.Add(exerciseType);
            await exerciseContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<ExerciseType> UpdateAsync(Guid exerciseTypeId, ExerciseType exerciseType)
        {
            var exerciseTypeToUpdate = await exerciseContext.ExerciseTypes.SingleAsync(et => et.Id == exerciseTypeId);
            
            exerciseTypeToUpdate.Name = exerciseType.Name;
            await exerciseContext.SaveChangesAsync();

            var updatedExerciseType = await exerciseContext.ExerciseTypes.SingleAsync(et => et.Id == exerciseTypeId);
            return updatedExerciseType;
        }

        public async Task<Guid> DeleteAsync(Guid exerciseTypeId)
        {
            var exerciseTypeToDelete = await exerciseContext.ExerciseTypes.SingleAsync(et => et.Id == exerciseTypeId);
            
            exerciseTypeToDelete.IsActive = false;
            await exerciseContext.SaveChangesAsync();

            return exerciseTypeToDelete.Id;
        }
    }
}
