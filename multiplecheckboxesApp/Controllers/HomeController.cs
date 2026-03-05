using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using multiplecheckboxesApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace multiplecheckboxesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext _studentContext;
        public HomeController(ILogger<HomeController> logger,StudentContext studentContext)
        {
            _logger = logger;
            _studentContext = studentContext;
        }

        public IActionResult Index()
        {
            var model = Bindcheck();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(Student students)
        {
            ModelState.Remove("favouriteSport");
            ModelState.Remove("checkboxMod");
            if (ModelState.IsValid)
            {
                if (students.Sports.Count > 0)
                {
                    var data = students.Sports;
                    if (data != null)
                    {
                        foreach (var i in data)
                        {
                            Student s = new Student()
                            {
                                name = students.name,
                                favouriteSport = i.ToString(),
                            };
                            _studentContext.student.Add(s);
                            _studentContext.SaveChanges();

                        }
                    }
                }
            }
            var model = Bindcheck();
            return View(model);
        }
        private Student Bindcheck()
        {
            var model = new Student()
            { 
                checkboxMod=new CheckboxModel()
                {
                    checkBoxes = new List<CheckBoxOption>
                    {
                        new CheckBoxOption()
                        {
                            IsChecked = true,
                            Text="Cricket",
                            Value="Cricket"
                        },
                         new CheckBoxOption()
                        {
                            IsChecked = true,
                            Text="Football",
                            Value="Football"
                        },
                        new CheckBoxOption()
                        {
                            IsChecked = true,
                            Text="Hockey",
                            Value="Hockey"
                        }
                    }
                }
            };           
            return model;
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
