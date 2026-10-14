using TrainingCenter.ConsoleApp.Entities;
using TrainingCenter.ConsoleApp.Services;

namespace TrainingCenter.ConsoleApp.UI
{
    public class StudentMenuActions
    {
        private readonly StudentService _studentService;

        public StudentMenuActions(StudentService studentService)
        {
            _studentService = studentService;
        }


        public void AddStudent()
        {
            Console.Clear();

            Student student = new Student();

            student.FirstName =
                InputHelper.ReadString("Enter First Name: ");

            student.LastName =
                InputHelper.ReadString("Enter Last Name: ");

            student.Email =
                InputHelper.ReadString("Enter Email: ");

            student.PhoneNumber =
                InputHelper.ReadString("Enter Phone Number: ");

            string status;

            while (true)
            {
                status = InputHelper.ReadString(
                    "Enter Status: (Active - Graduated - Suspended) ");

                if (status == "Active" ||
                    status == "Graduated" ||
                    status == "Suspended")
                {
                    break;
                }

                Console.WriteLine(
                    "Invalid Status. Please enter Active, Graduated, or Suspended.");
            }


            student.Status = status;


            while (true)
            {
                int year = InputHelper.ReadInt("Enter Birth Year: ");

                int month = InputHelper.ReadInt("Enter Birth Month: ");

                int day = InputHelper.ReadInt("Enter Birth Day: ");

                try
                {
                    student.DateOfBirth = new DateOnly(year, month, day);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid Date. Please enter a valid birth date.");
                }
            }
            student.RegisteredAt = DateTime.Now;

            _studentService.AddStudent(student);



            Console.WriteLine();
            Console.WriteLine("Student Added Successfully.");

            Console.ReadKey();
        }




        public void ShowAllStudents()
        {
            Console.Clear();

            List<Student> students =
                _studentService.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found.");
                Console.ReadKey();
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine(
                 $"{student.StudentId} - " +
                 $"{student.FirstName} {student.LastName} - " +
                 $"{student.Email} - " +
                 $"{student.Status}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");

            Console.ReadKey();
        }





        public void FindStudentById()
        {
            Console.Clear();

            int id =
                InputHelper.ReadInt("Enter Student Id: ");

            Student? student =
                _studentService.GetStudentById(id);

            if (student != null)
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Email: {student.Email}");
                Console.WriteLine($"Phone: {student.PhoneNumber}");
                Console.WriteLine($"Status: {student.Status}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");

            Console.ReadKey();
        }




        public void UpdateStudent()
        {
            Console.Clear();

            int id =
                InputHelper.ReadInt("Enter Student Id: ");

            Student? student =
                _studentService.GetStudentById(id);

            if (student == null)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");
                Console.ReadKey();
                return;
            }

            string firstName =
           InputHelper.ReadString("Enter New First Name: ");

            string lastName =
                InputHelper.ReadString("Enter New Last Name: ");

            string email =
                InputHelper.ReadString("Enter New Email: ");

            string phoneNumber =
                InputHelper.ReadString("Enter New Phone Number: ");

            string status;

            while (true)
            {
                status = InputHelper.ReadString("Enter Status: (Active - Graduated - Suspended) ");

                if (status == "Active" ||
                    status == "Graduated" ||
                    status == "Suspended")
                {
                    break;
                }

                Console.WriteLine("Invalid Status. Please enter Active, Graduated, or Suspended.");
            }


            bool success = _studentService.UpdateStudent(id, firstName,lastName,email, phoneNumber, status);

            Console.WriteLine();
            

            if (success)
            {
                Console.WriteLine("Student Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            Console.ReadKey();
        }




        public void DeleteStudent()
        {
            Console.Clear();

            int id = InputHelper.ReadInt("Enter Student Id: ");

            Student? student = _studentService.GetStudentById(id);

            if (student == null)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            bool success = _studentService.DeleteStudent(id);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine("Student Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            Console.ReadKey();
        }

    }
}