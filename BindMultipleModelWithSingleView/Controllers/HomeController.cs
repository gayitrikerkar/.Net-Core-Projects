using System.Diagnostics;
using BindMultipleModelWithSingleView.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindMultipleModelWithSingleView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ViewContext _viewContext;
        public HomeController(ILogger<HomeController> logger, ViewContext viewContext)
        {
            _logger = logger;
            _viewContext = viewContext;
        }

        public IActionResult Index()
        {
            var studentData = _viewContext.student.ToList();
            var teacherData = _viewContext.teacher.ToList();
            ViewModel v = new ViewModel()
            {
                StudentList = studentData,
                TeacherList = teacherData
            };
            return View(v);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
