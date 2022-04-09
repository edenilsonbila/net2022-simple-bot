using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Data
{
    public class Context : DbContext
    {
        private IConfiguration _configuration; 
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimpleUser>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SimpleUser> SimpleUsers { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
