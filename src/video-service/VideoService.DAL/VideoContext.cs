using VideoService.Core;
using Microsoft.EntityFrameworkCore;

namespace VideoService.DAL
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoChunk> VideoChunks { get; set; }
    }
}
