using System;
using System.Threading.Tasks;
using ExerciseVideoService.Core;

namespace ExerciseVideoService.DAL.Repositories
{
    public interface IExerciseVideoRepository
    {
        Task<ExerciseVideo> GetAsync(Guid exerciseVideoId);
        
        Task<ExerciseVideo> AddAsync(ExerciseVideo exerciseVideo);

        Task<ExerciseVideo> UpdateAsync(Guid exerciseVideoId, ExerciseVideo exerciseVideo);

        Task<Guid> DeleteAsync(Guid exerciseVideoId);
    }
}
