using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExerciseVideoService.DAL;
using ExerciseVideoService.Core;

namespace ExerciseVideoService.DAL.Repositories
{
    public class ExerciseVideoRepository
    {
        private readonly ExerciseVideoContext exerciseVideoContext;

        public ExerciseVideoRepository(ExerciseVideoContext exerciseVideoContext)
        {
            this.exerciseVideoContext = exerciseVideoContext;
        }

        public Task<ExerciseVideo> GetAsync(Guid exerciseVideoId)
        {
            return exerciseVideoContext.ExerciseVideos
                .SingleOrDefaultAsync(es => es.Id == exerciseVideoId);
        }
        
        public async Task<ExerciseVideo> AddAsync(ExerciseVideo exerciseVideo)
        {
            var entity = exerciseVideoContext.ExerciseVideos.Add(exerciseVideo);
            await exerciseVideoContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<ExerciseVideo> UpdateAsync(Guid exerciseVideoId, ExerciseVideo exerciseVideo)
        {
            var exerciseVideoToUpdate = await exerciseVideoContext.ExerciseVideos.SingleAsync(es => es.Id == exerciseVideoId);

            exerciseVideoToUpdate.Link = exerciseVideo.Link;
            exerciseVideoToUpdate.FPS = exerciseVideo.FPS;
            exerciseVideoToUpdate.Length = exerciseVideo.Length;
            exerciseVideoToUpdate.StartTime = exerciseVideo.StartTime;
            exerciseVideoToUpdate.ExercisePoints = exerciseVideo.ExercisePoints;
            await exerciseVideoContext.SaveChangesAsync();

            var updatedExerciseVideo = await exerciseVideoContext.ExerciseVideos.SingleAsync(es => es.Id == exerciseVideo.Id);
            return updatedExerciseVideo;
        }

        public async Task<Guid> DeleteAsync(Guid exerciseVideoId)
        {
            var exerciseVideoToDelete = await exerciseVideoContext.ExerciseVideos.SingleAsync(es => es.Id == exerciseVideoId);
            
            exerciseVideoContext.Remove(exerciseVideoToDelete);
            await exerciseVideoContext.SaveChangesAsync();

            return exerciseVideoToDelete.Id;
        }
    }
}
