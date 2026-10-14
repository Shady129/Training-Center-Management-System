using TrainingCenter.ConsoleApp.Entities;
using TrainingCenter.ConsoleApp.Services;

namespace TrainingCenter.ConsoleApp.UI
{
    public class CourseMenuActions
    {
        private readonly CourseService _courseService;

        public CourseMenuActions(CourseService courseService)
        {
            _courseService = courseService;
        }



        public void AddCourse()
        {
            Console.Clear();

            Course course = new Course();

            course.Code = InputHelper.ReadString("Enter Course Code: ");

            course.Title = InputHelper.ReadString("Enter Course Title: ");

            course.Description = InputHelper.ReadString("Enter Course Description: ");


       
            while (true)
            {
                course.Price = InputHelper.ReadDecimal("Enter Course Price: ");

                if (course.Price > 0)
                {
                    break;
                }

                Console.WriteLine("Price Must Be Greater Than Zero.");
            }




            string level;

            while (true)
            {
                level = InputHelper.ReadString("Enter Course Level:(Beginner - Intermediate - Advanced) ");

                if (level == "Beginner" ||
                    level == "Intermediate" ||
                    level == "Advanced")
                {
                    break;
                }

                Console.WriteLine(
                    "Invalid Level. Please enter Beginner, Intermediate, or Advanced.");
            }

            course.Level = level;




            int durationHours;

            while (true)
            {
                durationHours = InputHelper.ReadInt("Enter New Duration Hours: ");

                if (durationHours > 0)
                {
                    break;
                }

                Console.WriteLine("Duration Hours Must Be Greater Than Zero.");
            }
            course.DurationHours = durationHours;


            string status;

            while (true)
            {
                
                status = InputHelper.ReadString("Enter Course Status: (Draft - Published - Archived) ");


                if (status == "Draft" ||
                    status == "Published" ||
                    status == "Archived")
                {
                    break;
                }

                Console.WriteLine("Invalid Status. Please enter Draft, Published, or Archived.");
            }

            course.Status = status;


            course.CreatedAt = DateTime.Now;


            

            if (course.Status == "Published")
            {
                course.PublishedAt = DateTime.Now;
            }
            else
            {
                course.PublishedAt = null;
            }



            course.InstructorId = InputHelper.ReadInt("Enter Instructor Id: ");


            _courseService.AddCourse(course);

            Console.WriteLine();

            Console.WriteLine("Course Added Successfully.");

            Console.ReadKey();
        }

         

  

        public void ShowAllCourses()
        {
            Console.Clear();


            List<Course> courses = _courseService.GetAllCourses();

            if(courses.Count() == 0)
            {
                Console.WriteLine("No Courses Found.");

                Console.ReadKey();
                return;
            }


            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.CourseId} - " +
                    $"{course.Title} - " +
                    $"{course.Price}"
                );
            }
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");

            Console.ReadKey();
        }




        public void FindCourseById()
        {
            Console.Clear();

            int id =
                InputHelper.ReadInt("Enter Course Id: ");

            Course? course =
                _courseService.GetCourseById(id);

            if (course != null)
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {course.CourseId}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Price: {course.Price}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Continue...");

            Console.ReadKey();
        }




        public void UpdateCourse()
        {
            Console.Clear();

            int id = InputHelper.ReadInt("Enter Course Id: ");

            Course? course = _courseService.GetCourseById(id);

            if (course == null)
            {
                Console.WriteLine();
                Console.WriteLine("Course Not Found.");

                Console.ReadKey();
                return;
            }

            string code = InputHelper.ReadString("Enter New Code: ");

            string title = InputHelper.ReadString("Enter New Title: ");

            string description = InputHelper.ReadString("Enter New Description: ");


            decimal price;


            while (true)
            {

                price = InputHelper.ReadDecimal("Enter New Price: ");



                if (price > 0)
                {
                    break;
                }

                Console.WriteLine("Price Must Be Greater Than Zero.");
            }




            string level;

            while (true)
            {
                level = InputHelper.ReadString(
                    "Enter Course Level:(Beginner - Intermediate - Advanced) ");

                if (level == "Beginner" ||
                    level == "Intermediate" ||
                    level == "Advanced")
                {
                    break;
                }

                Console.WriteLine(
                    "Invalid Level. Please enter Beginner, Intermediate, or Advanced.");
            }

            course.Level = level;




            int durationHours;

            while (true)
            {
                durationHours =
                    InputHelper.ReadInt("Enter New Duration Hours: ");

                if (durationHours > 0)
                {
                    break;
                }

                Console.WriteLine("Duration Hours Must Be Greater Than Zero.");
            }




            string status;

            while (true)
            {

                status = InputHelper.ReadString("Enter Course Status: (Draft - Published - Archived) ");


                if (status == "Draft" ||
                    status == "Published" ||
                    status == "Archived")
                {
                    break;
                }

                Console.WriteLine("Invalid Status. Please enter Draft, Published, or Archived.");
            }

            course.Status = status;




            int instructorId = InputHelper.ReadInt("Enter New Instructor Id: ");



            bool success = _courseService.UpdateCourse(
                    id,
                    code,
                    title,
                    description,
                    price,
                    level,
                    durationHours,
                    status,
                    instructorId
                );


            Console.WriteLine();

            if (success)
            {
                Console.WriteLine(
                    "Course Updated Successfully.");
            }
            else
            {
                Console.WriteLine(
                    "Course Not Found.");
            }

            Console.ReadKey();
        }






        public void DeleteCourse()
        {
            Console.Clear();

            int id = InputHelper.ReadInt("Enter Course Id: ");

            bool success = _courseService.DeleteCourse(id);

            Console.WriteLine();

            if (success)
            {
                Console.WriteLine("Course Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Course Not Found.");
            }

            Console.ReadKey();
        }

    }
}