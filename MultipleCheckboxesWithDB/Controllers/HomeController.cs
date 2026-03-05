using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultipleCheckboxesWithDB.Models;

namespace MultipleCheckboxesWithDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cont _userContext;
        public HomeController(ILogger<HomeController> logger, Cont userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            var model = Bindcheck();
            return View(model);
            //var u = new User()
            //{
            //    checkboxModel = new CheckboxModel
            //    {
            //        checkBoxes = new List<CheckBoxOption>
            //        {
            //            new CheckBoxOption()
            //            {
            //                IsChecked = true,
            //                Text="Cricket",
            //                Value="Cricket"
            //            },
            //             new CheckBoxOption()
            //            {
            //                IsChecked = true,
            //                Text="Football",
            //                Value="Football"
            //            },
            //            new CheckBoxOption()
            //            {
            //                IsChecked = true,
            //                Text="Hockey",
            //                Value="Hockey"
            //            },
            //        }
            //    }
            //};
            //return View(u);
        }
        [HttpPost]
        public IActionResult Index(CheckboxModel user)
        {
            ModelState.Remove("favouriteSport");
            ModelState.Remove("checkBoxes");
            if (ModelState.IsValid)
            {
                var data = user.Sports;     
                foreach(var i in data)
                {
                    CheckboxModel c = new CheckboxModel()
                    {
                        name = user.name,
                        favouriteSport = i.ToString()
                    };
                     _userContext.user.Add(c);
                    _userContext.SaveChanges();
                     
                }

            }
            var model = Bindcheck();
            return View(model);
        }

        private CheckboxModel Bindcheck()
        {
            var model = new CheckboxModel()
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
