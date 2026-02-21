using CTMS.Repository.Data.Configurations;
using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTMS.Repository.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CTMS;Trusted_Connection=True;TrustServerCertificate=True");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfigure());
            modelBuilder.ApplyConfiguration(new DepartmentConfigure());
            modelBuilder.ApplyConfiguration(new TrainerEmployeeConfigure());
            modelBuilder.ApplyConfiguration(new EnrolledEmployeeConfigure());
            modelBuilder.ApplyConfiguration(new TrainingProgramConfigure());
        }

       public DbSet<Employee> Employees { get; set; } 
       public DbSet<Department> Departments { get; set; }
       public DbSet<TrainerEmployee> TrainerEmployees { get; set; } 
       public DbSet<EnrolledEmployee> EnrolledEmployees { get; set; } 
       public DbSet<TrainingProgram> TrainingPrograms  { get; set; } 

    }
}
