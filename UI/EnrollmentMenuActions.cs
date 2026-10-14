using TrainingCenter.ConsoleApp.Entities;
using TrainingCenter.ConsoleApp.Services;

namespace TrainingCenter.ConsoleApp.UI
{
    public class EnrollmentMenuActions
    {

        private readonly EnrollmentService _enrollmentService;

        public EnrollmentMenuActions(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }


        public void RegisterStudentInCourse()
        {
            Console.Clear();

            int studentId = InputHelper.ReadInt("Enter Student Id: ");


            bool studentExists = _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }


            int courseId = InputHelper.ReadInt("Enter Course Id: ");


            string message = _enrollmentService.RegisterStudentInCourse(studentId, courseId);

            Console.WriteLine();
            Console.WriteLine(message);

            Console.ReadKey();
        }




        public void ShowStudentCourses()
        {
            Console.Clear();

            int studentId =
                InputHelper.ReadInt("Enter Student Id: ");

            bool studentExists = _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            List<Enrollment> enrollments = _enrollmentService.GetStudentCourses(studentId);

            if (enrollments.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No Courses Found For This Student.");

                Console.ReadKey();
                return;
            }

            foreach (var enrollment in enrollments)
            {
                Console.WriteLine(
                    $"{enrollment.Course.CourseId} - " +
                    $"{enrollment.Course.Title} - " +
                    $"{enrollment.Course.Price} - " +
                    $"{enrollment.Status}"
                );
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }




        public void ShowCourseStudents()
        {
            Console.Clear();

            int courseId =
                InputHelper.ReadInt("Enter Course Id: ");

            bool courseExists =
                _enrollmentService.CourseExists(courseId);

            if (!courseExists)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }

            List<Enrollment> enrollments =
                _enrollmentService.GetCourseStudents(courseId);

            if (enrollments.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No Students Found In This Course.");

                Console.ReadKey();
                return;
            }

            foreach (var enrollment in enrollments)
            {
                Console.WriteLine(
                    $"{enrollment.Student.StudentId} - " +
                    $"{enrollment.Student.FirstName} " +
                    $"{enrollment.Student.LastName} - " +
                    $"{enrollment.Status}"
                );
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }





        public void UpdateEnrollmentProgress()
        {
            Console.Clear();

            int studentId =
                InputHelper.ReadInt("Enter Student Id: ");

            bool studentExists =
                _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            int courseId =
                InputHelper.ReadInt("Enter Course Id: ");

            bool courseExists =
                _enrollmentService.CourseExists(courseId);

            if (!courseExists)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }



            List<Enrollment> enrollments =
                _enrollmentService.GetStudentCourses(studentId);

            bool enrollmentExists =
                enrollments.Any(e =>
                    e.CourseId == courseId);

            if (!enrollmentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Enrollment Not Found.");

                Console.ReadKey();
                return;
            }




            decimal progress;

            while (true)
            {
                progress = InputHelper.ReadDecimal("Enter Progress Percent: ");

                if (progress >= 0 && progress <= 100)
                {
                    break;
                }

                Console.WriteLine(
                    "Progress Must Be Between 0 and 100.");
            }



            bool success = _enrollmentService.UpdateProgress(studentId, courseId, progress);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine(
                    "Progress Updated Successfully.");
            }

            Console.ReadKey();
        }








        public void UpdateFinalGrade()
        {
            Console.Clear();

            int studentId = InputHelper.ReadInt("Enter Student Id: ");


            bool studentExists =  _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            int courseId = InputHelper.ReadInt("Enter Course Id: ");


            bool courseExists = _enrollmentService.CourseExists(courseId);

            if (!courseExists)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }

            List<Enrollment> enrollments = _enrollmentService.GetStudentCourses(studentId);


            bool enrollmentExists =
                enrollments.Any(e =>
                    e.CourseId == courseId);

            if (!enrollmentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Enrollment Not Found.");

                return;
            }

            decimal finalGrade;

            while (true)
            {
                finalGrade = InputHelper.ReadDecimal("Enter Final Grade: ");

                if (finalGrade >= 0 && finalGrade <= 100)
                {
                    break;
                }

                Console.WriteLine("Final Grade Must Be Between 0 and 100.");
            }

   


            bool success = _enrollmentService.UpdateFinalGrade(studentId, courseId,finalGrade);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine("Final Grade Updated Successfully.");
            }
            Console.ReadKey();
        }




        public void UpdateEnrollmentStatus()
        {
            Console.Clear();

            int studentId = InputHelper.ReadInt("Enter Student Id: ");

            bool studentExists = _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            int courseId = InputHelper.ReadInt("Enter Course Id: ");


            bool courseExists = _enrollmentService.CourseExists(courseId);

            if (!courseExists)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }

            List<Enrollment> enrollments = _enrollmentService.GetStudentCourses(studentId);

            bool enrollmentExists =
                enrollments.Any(e =>
                    e.CourseId == courseId);

            if (!enrollmentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Enrollment Not Found.");

                Console.ReadKey();
                return;
            }




            string status;

            while (true)
            {
                status = InputHelper.ReadString("Enter New Status: (Active - Completed - Dropped) ");

                if (status == "Active" ||
                    status == "Completed" ||
                    status == "Dropped")
                {
                    break;
                }

                Console.WriteLine(
                    "Invalid Status. Please enter Active, Completed, or Dropped.");
            }
       



            bool success = _enrollmentService.UpdateStatus(studentId, courseId, status);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine("Enrollment Status Updated Successfully.");
            }

            Console.ReadKey();
        }




        public void CompleteEnrollment()
        {
            Console.Clear();

            int studentId = InputHelper.ReadInt("Enter Student Id: ");

            bool studentExists =
                _enrollmentService.StudentExists(studentId);

            if (!studentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Student Not Found.");

                Console.ReadKey();
                return;
            }

            int courseId = InputHelper.ReadInt("Enter Course Id: ");

            bool courseExists = _enrollmentService.CourseExists(courseId);

            if (!courseExists)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }


            List<Enrollment> enrollments = _enrollmentService.GetStudentCourses(studentId);



            bool enrollmentExists =
                enrollments.Any(e =>
                    e.CourseId == courseId);

            if (!enrollmentExists)
            {
                Console.WriteLine();
                Console.WriteLine("Enrollment Not Found.");

                Console.ReadKey();
                return;
            }

            bool success = _enrollmentService.CompleteEnrollment(studentId, courseId);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine("Enrollment Completed Successfully.");
            }

            Console.ReadKey();
        }
    }
}
