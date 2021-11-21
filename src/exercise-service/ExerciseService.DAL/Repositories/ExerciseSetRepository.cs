using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseService.Core;
using ExerciseService.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.DAL.Repositories
{
    public class ExerciseSetRepository : IExerciseSetRepository
    {
        private readonly ExerciseContext exerciseContext;

        public ExerciseSetRepository(ExerciseContext exerciseContext)
        {
            this.exerciseContext = exerciseContext;
        }

        public Task<ExerciseSet> GetAsync(Guid exerciseSetId)
        {
            return exerciseContext.ExerciseSets
                .SingleOrDefaultAsync(es => es.Id == exerciseSetId);
        }

        public async Task<IEnumerable<ExerciseSet>> GetByExerciseDayAsync(Guid userId, DateTime date)
        {
            return await exerciseContext.ExerciseSets
                .Include(es => es.ExerciseType)
                .Where(es => es.UserId == userId && es.Date == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseSet>> GetByExerciseTypeAsync(Guid userId, Guid exerciseTypeId)
        {
            return await exerciseContext.ExerciseSets
                .Include(es => es.ExerciseType)
                .Where(es => es.UserId == userId && es.ExerciseType.Id == exerciseTypeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseSet>> GetByExerciseTypeAsync(Guid userId, string exerciseTypeName)
        {
            return await exerciseContext.ExerciseSets
                .Include(es => es.ExerciseType)
                .Where(es => es.UserId == userId && es.ExerciseType.Name == exerciseTypeName)
                .ToListAsync();
        }

        public async Task<ExerciseSet> AddAsync(ExerciseSet exerciseSet)
        {
            var entity = exerciseContext.ExerciseSets.Add(exerciseSet);
            await exerciseContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<ExerciseSet> UpdateAsync(Guid exerciseSetId, ExerciseSet exerciseSet)
        {
            var exerciseSetToUpdate = await exerciseContext.ExerciseSets.SingleAsync(es => es.Id == exerciseSetId);

            exerciseSetToUpdate.ExerciseType = exerciseSet.ExerciseType;
            exerciseSetToUpdate.Weight = exerciseSet.Weight;
            exerciseSetToUpdate.RepCount = exerciseSet.RepCount;
            exerciseSetToUpdate.Date = exerciseSet.Date;
            exerciseSetToUpdate.TrackingVideoId = exerciseSet.TrackingVideoId;
            await exerciseContext.SaveChangesAsync();

            var updatedExerciseSet = await exerciseContext.ExerciseSets.SingleAsync(es => es.Id == exerciseSet.Id);
            return updatedExerciseSet;
        }

        public async Task<Guid> DeleteAsync(Guid exerciseSetId)
        {
            var exerciseSetToDelete = await exerciseContext.ExerciseSets.SingleAsync(es => es.Id == exerciseSetId);
            
            exerciseContext.Remove(exerciseSetToDelete);
            await exerciseContext.SaveChangesAsync();

            return exerciseSetToDelete.Id;
        }
    }
}
