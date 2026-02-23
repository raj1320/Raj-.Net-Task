using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CTMS.Repository.Data.Configurations
{
    public class EmployeeConfigure : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                    .IsRequired(true)
                    .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                   .IsUnique(true);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.Address)
                    .IsRequired(true)
                    .HasMaxLength(100);

            builder.Property(x => x.Salary)
                   .HasColumnType("decimal(10,2)");

            builder.Property(x => x.IsTrainer)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsEnrolled)
                   .HasDefaultValue(false);

            builder.Property(x => x.YearsOfExperties)
                   .IsRequired(true);

            builder.Property(x => x.Designation)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.DepartmentId)
                .IsRequired(true);


            builder.HasData(
               new Employee { Id = 1, Name = "Raj Rana", Email ="raj123@gmail.com", DepartmentId=1 , Designation="Software Developer" , YearsOfExperties = 3 , PhoneNumber="7046192318" , Address="khambhat" , Salary=40000 , IsEnrolled = false, IsTrainer=false  },
               new Employee { Id = 2, Name = "Vadher Ravi", Email ="ravi123@gmail.com", DepartmentId=1 , Designation="Software Developer" , YearsOfExperties = 3 , PhoneNumber="8046192318" , Address="Lodhva" , Salary=40000 , IsEnrolled = false, IsTrainer=false  },
               new Employee { Id = 3, Name = "Rakesh Parmar", Email ="rakesh123@gmail.com", DepartmentId=2 , Designation="Salse Executive" , YearsOfExperties = 2 , PhoneNumber="8146192318" , Address="Vadhvan" , Salary=30000 , IsEnrolled = false, IsTrainer=false  },
               new Employee { Id = 4, Name = "Yashraj Vaghela", Email ="yashraj123@gmail.com", DepartmentId=3 , Designation= "Salse Executive", YearsOfExperties = 2 , PhoneNumber="7746192318" , Address="Gondal" , Salary=20000 , IsEnrolled = false, IsTrainer=false  },
               new Employee { Id = 5, Name = "Akash Pateliya", Email ="akash123@gmail.com", DepartmentId=3 , Designation="Marketing Intern" , YearsOfExperties = 1 , PhoneNumber="7846192318" , Address="Rajkot" , Salary=5000 , IsEnrolled = false, IsTrainer= false },
               new Employee { Id = 6, Name = "Mehul Prajapati", Email ="mehul123@gmail.com", DepartmentId=4 , Designation="QA Developer" , YearsOfExperties = 3 , PhoneNumber="8086192318" , Address="Nadiyad" , Salary=40000 , IsEnrolled = false, IsTrainer= false },
               new Employee { Id = 7, Name = "Sujal Prajapati", Email ="sujal123@gmail.com", DepartmentId=5 , Designation="Accountent" , YearsOfExperties = 4 , PhoneNumber="7946192318" , Address="Anand" , Salary=50000 , IsEnrolled = false, IsTrainer=false  }
               
             );

        }
    }
}
