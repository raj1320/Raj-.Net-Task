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
            _Context.SaveChanges();
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
            var courses= _Context.Courses;
            return courses.ToList();
        }
    }
}
