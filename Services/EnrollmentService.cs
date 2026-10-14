using Microsoft.EntityFrameworkCore;
using TrainingCenter.ConsoleApp.Data;
using TrainingCenter.ConsoleApp.Entities;




namespace TrainingCenter.ConsoleApp.Services
{
    public class EnrollmentService
    {
        private readonly AppDbContext _context;



        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }




        public string RegisterStudentInCourse(
       int studentId,
       int courseId)
        {
            bool studentExists =
                _context.Students
                .Any(s => s.StudentId == studentId);

            if (!studentExists)
            {
                return "Student Not Found.";
            }

            bool courseExists =
                _context.Courses
                .Any(c => c.CourseId == courseId);

            if (!courseExists)
            {
                return "Course Not Found.";
            }

            bool exists =
                _context.Enrollments.Any(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);

            if (exists)
            {
                return "Student Already Registered In This Course.";
            }

            Enrollment enrollment = new Enrollment();

            enrollment.StudentId = studentId;
            enrollment.CourseId = courseId;
            enrollment.EnrollmentDate = DateTime.Now;
            enrollment.ProgressPercent = 0;
            enrollment.Status = "Active";

            _context.Enrollments.Add(enrollment);

            _context.SaveChanges();

            return "Registration Completed.";
        }




        public List<Enrollment> GetStudentCourses(int studentId)
        {
            return _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToList();
        }





        public List<Enrollment> GetCourseStudents(int courseId)
        {
            return _context.Enrollments
                .Include(e => e.Student)
                .Where(e => e.CourseId == courseId)
                .ToList();
        }





        public bool UpdateProgress(int studentId, int courseId, decimal progressPercent)
        {
            Enrollment? enrollment =
                _context.Enrollments
                .FirstOrDefault(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);

            if (enrollment == null)
            {
                return false;
            }

            enrollment.ProgressPercent = progressPercent;


            if (progressPercent == 100)
            {
                enrollment.Status = "Completed";
                enrollment.CompletionDate = DateTime.Now;
            }


            _context.SaveChanges();

            return true;
        }




        public bool UpdateFinalGrade(int studentId, int courseId, decimal finalGrade)
        {
            Enrollment? enrollment =
                _context.Enrollments
                .FirstOrDefault(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);

            if (enrollment == null)
            {
                return false;
            }

            enrollment.FinalGrade = finalGrade;

            _context.SaveChanges();

            return true;
        }





        public bool UpdateStatus(int studentId,int courseId, string status)
        {
            Enrollment? enrollment =
                _context.Enrollments
                .FirstOrDefault(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);

            if (enrollment == null)
            {
                return false;
            }

            enrollment.Status = status;

            _context.SaveChanges();

            return true;
        }


        public bool CompleteEnrollment(int studentId, int courseId)
        {
            Enrollment? enrollment =
                _context.Enrollments
                .FirstOrDefault(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);

            if (enrollment == null)
            {
                return false;
            }

            enrollment.Status = "Completed";
            enrollment.ProgressPercent = 100;
            enrollment.FinalGrade ??= 100;
            enrollment.CompletionDate = DateTime.Now;

            _context.SaveChanges();

            return true;
        }






        public bool StudentExists(int studentId)
        {
            return _context.Students
                .Any(s => s.StudentId == studentId);
        }







        public bool CourseExists(int courseId)
        {
            return _context.Courses
                .Any(c => c.CourseId == courseId);
        }






    }
}



