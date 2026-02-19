using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;


namespace EFCoreDay1.Repository
{
    public class CourseRepository
    {
        public AppDbContext _Context;

        public CourseRepository(AppDbContext _context)
        {
            this._Context = _context;
        }

        public Course AddCourse(Course course)
        {
            _Context.Courses.Add(course);
            Console.WriteLine("Course Entity Before Save Change :" + _Context.Entry(course).State);
            _Context.SaveChanges();
            Console.WriteLine("Course Entity After Save Change :" + _Context.Entry(course).State);
            return course;
        }

        public Course? GetCourse(int Id)
        {
            var course = _Context.Courses.Include(c => c.Students)
                                               .Include(c => c.Batches)
                                               .SingleOrDefault(x => x.Id == Id);
            return course;
        }

        public List<Course> GetALLCourses()
        {
            
            return _Context.Courses.ToList();
        }

        public Course? UpdateCourseTitle(int Id , string Title)
        {
            var course  = _Context.Courses.FirstOrDefault(x=>x.Id==Id);
            if (course != null) 
            { 
                course.Title = Title=="Test" ? course.Title : Title ;
                Console.WriteLine("Course Entity Before Save Change :" + _Context.Entry(course).State);
                _Context.SaveChanges();
                Console.WriteLine("Course Entity After Save Change :" + _Context.Entry(course).State);
                Console.WriteLine("Title Updated successfully..");
                return course;  
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }
        }

        public Course? UpdateCourseFees(int Id,double Fees)
        {
            var course = _Context.Courses.FirstOrDefault(x => x.Id == Id);
            if (course != null)
            {
                course.Fees = Fees;
                Console.WriteLine("Course Entity Before Save Change :" + _Context.Entry(course).State);
                _Context.SaveChanges();
                Console.WriteLine("Course Entity After Save Change :" + _Context.Entry(course).State);
                Console.WriteLine("Fees Updated successfully..");
                return course;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }
        }
        public Course? UpdateCourseDurationInMonths(int Id, int DurationInMonths)
        {
            var course = _Context.Courses.FirstOrDefault(x => x.Id == Id);
            if (course != null)
            {
                course.DurationInMonths = DurationInMonths;
                Console.WriteLine("Course Entity Before Save Change :" + _Context.Entry(course).State);
                _Context.SaveChanges();
                Console.WriteLine("Course Entity After Save Change :" + _Context.Entry(course).State);
                Console.WriteLine("DurationInMonths Updated successfully..");
                return course;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }
}

        public bool Delete(int Id)
        {
            var course = _Context.Courses.FirstOrDefault(x => x.Id == Id);

            if (course != null)
            {
                _Context.Courses.Remove(course);
                Console.WriteLine("Course Entity Before Save Change :" + _Context.Entry(course).State);
                _Context.SaveChanges();
                Console.WriteLine("Course Entity After Save Change :" + _Context.Entry(course).State);
                Console.WriteLine("Deleted Successfully..");
                return true;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return false;
            }

        }
    }
}
