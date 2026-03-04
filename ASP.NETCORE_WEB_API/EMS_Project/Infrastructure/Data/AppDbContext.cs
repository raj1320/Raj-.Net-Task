using EMS_Project.Domain.Entities;
using EMS_Project.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EMS_Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RegisteredEvent> RegisteredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new RegisteredConfiguration());
        }
    }
}
