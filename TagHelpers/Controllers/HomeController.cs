using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TagHelpers.Models;

namespace TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
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
        public int About(int id)
        {
            return id;
        }
        public IActionResult FormTest()
        {
            return View();
        }
        [HttpPost]
        public string FormTest(Student s)
        {
            return "RollNo: "+s.RollNo+" Name : "+s.Name + " Age: "+s.Age+" Gender: "+s.Gender+" Marrtial status: "+s.Married+" Address: "+s.Address;
        }
        public string Details(int id,string name)
        {
            return "the Id is:" + id + "and the name is:" + name;
        }
    }
}
