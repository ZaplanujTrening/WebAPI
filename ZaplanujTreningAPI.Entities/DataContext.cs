using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZaplanujTreningAPI.Entities.Entities;

namespace ZaplanujTreningAPI.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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
