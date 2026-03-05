using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sessions.Models;

namespace Sessions.Controllers
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
            HttpContext.Session.SetString("user", "me");
            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("user")!=null)
            {
                ViewBag.data = HttpContext.Session.GetString("user").ToString();
            }
            return View();
        }
        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                ViewBag.data = HttpContext.Session.GetString("user").ToString();
            }
            return View();
        }
        public IActionResult About()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                ViewBag.data = HttpContext.Session.GetString("user").ToString();
            }
            return View();
        }
        public IActionResult first()
        {
            return View();
        }
        public IActionResult Destroy()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.Remove("user");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
