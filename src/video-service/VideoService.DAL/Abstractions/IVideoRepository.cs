using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoService.Core;

namespace VideoService.DAL.Abstractions
{
    public interface IVideoRepository
    {
        Task<Video> GetAsync(Guid videoId);
        Task<IEnumerable<Video>> GetByUserIdAsync(Guid userId);
        Task<Video> AddAsync(Video video);
        Task<Guid> DeleteAsync(Guid videoId);
    }
}