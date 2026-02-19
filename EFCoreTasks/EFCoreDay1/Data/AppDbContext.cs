
using EFCoreDay1.Configuration;
using EFCoreDay1.Entities;
using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace EFCoreDay1.Data
{
    public class AppDbContext : DbContext
    {

        public static bool EnableLazyLoadingLogging = false;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCOREDEMO;Trusted_Connection=True;TrustServerCertificate=True")
                .UseLazyLoadingProxies()
                .LogTo(
                    Console.WriteLine,
                    (eventId, logLevel) =>
                        EnableLazyLoadingLogging &&                  
                        eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted" &&
                        logLevel == LogLevel.Information
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainerConfigur());
            modelBuilder.ApplyConfiguration(new BatchesConfigur());
        }

       public  DbSet<Student> Students { get; set; }
       public DbSet<Course> Courses { get; set; }   
       public DbSet<Trainer> Trainers { get; set; }
       public DbSet<Batch>Batches { get; set; }
       public DbSet<Clubs> Clubs { get; set; }
    }
}
