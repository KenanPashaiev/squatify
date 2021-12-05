using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoService.Core;
using VideoService.DAL.Abstractions;

namespace VideoService.DAL.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoContext videoContext;

        public VideoRepository(VideoContext videoContext)
        {
            this.videoContext = videoContext;
        }

        public Task<Video> GetAsync(Guid videoId)
        {
            return videoContext.Videos.Include(v => v.VideoChunks)
                .SingleOrDefaultAsync(es => es.Id == videoId);
        }

        public async Task<IEnumerable<Video>> GetByUserIdAsync(Guid userId)
        {
            return await videoContext.Videos
                .Where(es => es.UserId == userId).ToListAsync();
        }

        public async Task<Video> AddAsync(Video video)
        {
            var entity = videoContext.Videos.Add(video);
            await videoContext.SaveChangesAsync();
            return entity.Entity;
        }
        
        public async Task<Guid> DeleteAsync(Guid videoId)
        {
            var videoToDelete = await videoContext.Videos.SingleAsync(v => v.Id == videoId);
            
            videoContext.Remove(videoToDelete);
            await videoContext.SaveChangesAsync();

            return videoToDelete.Id;
        }
    }
}