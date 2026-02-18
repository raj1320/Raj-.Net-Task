
using EFCoreDay1.Configuration;
using EFCoreDay1.Entities;
using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCoreDay1.Data
{
    public class AppDbContext : DbContext
    {
               
        protected  override void OnConfiguring(DbContextOptionsBuilder Optionbuilder)
        {
            Optionbuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCOREDEMO;Trusted_Connection=True;TrustServerCertificate=True");
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
    }
}
