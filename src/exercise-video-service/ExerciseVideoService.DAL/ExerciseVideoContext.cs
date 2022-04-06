using ExerciseVideoService.Core;
using Microsoft.EntityFrameworkCore;

namespace ExerciseVideoService.DAL
{
    public class ExerciseVideoContext : DbContext
    {
        public ExerciseVideoContext(DbContextOptions<ExerciseVideoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ExerciseVideo> ExerciseVideos { get; set; }
        public DbSet<ExercisePoint> ExercisePoints { get; set; }
    }
}
