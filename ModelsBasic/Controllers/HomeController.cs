using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelsBasic.Models;
using ModelsBasic.Repository;

namespace ModelsBasic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentRepository  _studentRepository = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _studentRepository = new StudentRepository();
        }
        public List<StudentModel> getAllStudents()
        {
            return _studentRepository.getAllStudents();
        }
        public StudentModel getById(int id)
        {
            return _studentRepository.getStudentById(id);
        }
        public IActionResult Index()
        {
            var students = new List<StudentModel>
            { 
            new StudentModel {RollNo=1,Name="Rucha",Standard=10} ,
              new StudentModel {RollNo=2,Name="Geet",Standard=11} ,
                new StudentModel {RollNo=3,Name="Prit",Standard=12} 
            };
            ViewData["students"]=students;
            return View();
        }

        public IActionResult Privacy()
        {//passing single student to view
         //StudentModel obj = new StudentModel()
         //{
         //    RollNo = 1,
         //    Name = "rucha",
         //    Standard = 20
         //};

            //passing list of students
            var students = new List<StudentModel>
            {
            new StudentModel {RollNo=1,Name="Rucha",Standard=10} ,
              new StudentModel {RollNo=2,Name="Geet",Standard=11} ,
                new StudentModel {RollNo=3,Name="Prit",Standard=12}
            };
            return View(students);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
