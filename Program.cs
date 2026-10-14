using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrainingCenter.ConsoleApp.Data;
using TrainingCenter.ConsoleApp.Entities;
using TrainingCenter.ConsoleApp.Services;
using TrainingCenter.ConsoleApp.UI;





IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

string? connectionString =
    configuration.GetConnectionString("DefaultConnection");

var options =
    new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(connectionString)
        .Options;




using var context = new AppDbContext(options);






StudentService studentService = new StudentService(context);
CourseService courseService = new CourseService(context);
EnrollmentService enrollmentService = new EnrollmentService(context);



Menu menu = new Menu(studentService, courseService, enrollmentService);

menu.ShowMainMenu();
























