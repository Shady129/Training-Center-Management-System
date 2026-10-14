
using TrainingCenter.ConsoleApp.Data;
using TrainingCenter.ConsoleApp.Entities;

namespace TrainingCenter.ConsoleApp.Services
{
    public class CourseService
    {

        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }



        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }




        public Course? GetCourseById(int id)
        {
            return _context.Courses
                           .FirstOrDefault(c => c.CourseId == id);
        }




        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);

            _context.SaveChanges();
        }



        public bool UpdateCourse(
            int id,
            string code,
            string title,
            string description,
            decimal price,
            string level,
            int durationHours,
            string status,
            int instructorId)
        {
            Course? course = GetCourseById(id);

            if (course == null)
            {
                return false;
            }

            course.Code = code;
            course.Title = title;
            course.Description = description;
            course.Price = price;
            course.Level = level;
            course.DurationHours = durationHours;
            course.Status = status;

            if (course.Status == "Published")
            {
                course.PublishedAt = DateTime.Now;
            }
            else
            {
                course.PublishedAt = null;
            }

            course.InstructorId = instructorId;
            

            _context.SaveChanges();

            return true;
        }





        public bool DeleteCourse(int id)
        {
            Course? course = GetCourseById(id);

            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);

            _context.SaveChanges();

            return true;
        }


    }
}
