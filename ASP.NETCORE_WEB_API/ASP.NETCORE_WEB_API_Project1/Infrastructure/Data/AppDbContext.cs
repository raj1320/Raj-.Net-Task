using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCORE_WEB_API_Project1.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }


    }
}
