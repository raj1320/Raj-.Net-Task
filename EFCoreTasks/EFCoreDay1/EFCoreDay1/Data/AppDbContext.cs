
using EFCoreDay1.Entities;
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

        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }        

    }
}
