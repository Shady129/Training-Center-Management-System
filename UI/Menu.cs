using TrainingCenter.ConsoleApp.Services;

namespace TrainingCenter.ConsoleApp.UI
{
    public class Menu
    {
        private readonly StudentService _studentService;
        private readonly StudentMenuActions _studentMenuActions;
        private readonly CourseMenuActions _courseMenuActions;
        private readonly EnrollmentMenuActions _enrollmentMenuActions;

        public Menu(StudentService studentService, CourseService courseService,  EnrollmentService enrollmentService)
        {
            _studentService = studentService;

            _studentMenuActions = new StudentMenuActions(studentService);

            _courseMenuActions = new CourseMenuActions(courseService);

            _enrollmentMenuActions = new EnrollmentMenuActions(enrollmentService);
        }


        public void ShowMainMenu()
        {


            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== Student Management System =====");
                Console.WriteLine("1.  Add Student");
                Console.WriteLine("2.  Show All Students");
                Console.WriteLine("3.  Find Student By Id");
                Console.WriteLine("4.  Update Student");
                Console.WriteLine("5.  Delete Student");
                Console.WriteLine("6.  Add Course");
                Console.WriteLine("7.  Show All Courses");
                Console.WriteLine("8.  Find Course By Id");
                Console.WriteLine("9.  Update Course");
                Console.WriteLine("10. Delete Course");
                Console.WriteLine("11. Register Student In Course");
                Console.WriteLine("12. Show Student Courses");
                Console.WriteLine("13. Show Course Students");
                Console.WriteLine("14. Update Enrollment Progress");
                Console.WriteLine("15. Update Final Grade");
                Console.WriteLine("16. Update Enrollment Status");
                Console.WriteLine("17. Complete Enrollment");
                Console.WriteLine("0.  Exit");



                int choice = InputHelper.ReadInt("Enter Your Choice: ");


                switch (choice)
                {

                    case 1:
                        _studentMenuActions.AddStudent();
                        break;


                    case 2:
                        _studentMenuActions.ShowAllStudents();
                        break;


                    case 3:
                        _studentMenuActions.FindStudentById();
                        break;



                    case 4:
                        _studentMenuActions.UpdateStudent();
                        break;


                    case 5:
                        _studentMenuActions.DeleteStudent();
                        break;


                    case 6:
                        _courseMenuActions.AddCourse();
                        break;


                    case 7:
                        _courseMenuActions.ShowAllCourses();
                        break;


                    case 8:
                        _courseMenuActions.FindCourseById();
                        break;


                    case 9:
                        _courseMenuActions.UpdateCourse();
                        break;


                    case 10:
                        _courseMenuActions.DeleteCourse();
                        break;


                    case 11:
                        _enrollmentMenuActions.RegisterStudentInCourse();
                        break;


                    case 12:
                        _enrollmentMenuActions.ShowStudentCourses();
                        break;


                    case 13:
                         _enrollmentMenuActions.ShowCourseStudents();
                          break;


                    case 14:
                        _enrollmentMenuActions.UpdateEnrollmentProgress();
                        break;


                    case 15:
                        _enrollmentMenuActions.UpdateFinalGrade();
                        break;

                    case 16:
                        _enrollmentMenuActions.UpdateEnrollmentStatus();
                        break;


                    case 17:
                            
                        _enrollmentMenuActions.CompleteEnrollment();
                        break;


                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;

                }
            }
        }
    }
}
