using System.Diagnostics;
using Checkboxes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkboxes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CheckboxContext _checkDBContext;
        public HomeController(ILogger<HomeController> logger, CheckboxContext chkDBContext)
        {
            _logger = logger;
            _checkDBContext = chkDBContext;
        }

        public IActionResult Index()
        {
            var model = new CheckboxModel()
            { 
                AcceptTerms = false,
                text="I accept the terms"
            };
            return View(model);
        }
        //[HttpPost]
        //public IActionResult Index(CheckboxModel checkboxModel)
        //{
        //    var data = checkboxModel.AcceptTerms;
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Index(CheckboxModel checkboxModel)
        {
            ModelState.Remove("text");
            if (ModelState.IsValid)
            {
                await _checkDBContext.checkboxMod.AddAsync(checkboxModel);//async and await is used because asp.net core recommends to use async and await
                await _checkDBContext.SaveChangesAsync();
              //  TempData["insertMsg"] = "Record inserted";//tempdata is used because we need this message to be seen only after one request
                return RedirectToAction("Index", "Home");
            }
            return View(checkboxModel);//incase of errors we are passing student object so that we can see our passed data in url
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
