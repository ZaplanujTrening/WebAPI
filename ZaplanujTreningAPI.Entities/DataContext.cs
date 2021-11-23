using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingRoutines> TrainingRoutines { get; set; }
        public DbSet<MusclePart> MuscleParts { get; set; }
        public DbSet<Dimentions> Dimentions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ZaplanujTreningDB"));
        }
    }
}
