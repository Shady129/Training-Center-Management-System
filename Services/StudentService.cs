using TrainingCenter.ConsoleApp.Data;
using TrainingCenter.ConsoleApp.Entities;
namespace TrainingCenter.ConsoleApp.Services
{
    public class StudentService
    {

        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }




        public int GetStudentsCount()
        {
            return _context.Students.Count();
        }



        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }





        public void AddStudent(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }




        public Student? GetStudentById(int id)
        {
            return _context.Students
                .FirstOrDefault(s => s.StudentId == id);
        }





        public bool UpdateStudent(int id,string firstName, string lastName, string email, string phoneNumber,string status)
        {
            Student? student = GetStudentById(id);

            if (student == null)
            {
                return false;
            }

            student.FirstName = firstName;
            student.LastName = lastName;
            student.Email = email;
            student.PhoneNumber = phoneNumber;
            student.Status = status;

            _context.SaveChanges();

            return true;
        }






        public bool DeleteStudent(int id)
        {
            Student? student = GetStudentById(id);

            if (student == null)
            {
                return false;
            }

            var enrollments = _context.Enrollments
                .Where(e => e.StudentId == id)
                .ToList();

            _context.Enrollments.RemoveRange(enrollments);

            _context.Students.Remove(student);

            _context.SaveChanges();

            return true;
        }

    }
}
