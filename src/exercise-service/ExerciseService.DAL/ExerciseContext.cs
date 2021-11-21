using ExerciseService.Core;
using Microsoft.EntityFrameworkCore;

namespace ExerciseService.DAL
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
    }
}
