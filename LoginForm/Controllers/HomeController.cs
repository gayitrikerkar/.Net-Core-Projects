using System.Diagnostics;
using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginContext _context;
        public HomeController(ILogger<HomeController> logger, LoginContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var myuser =_context.Users.Where(x=>x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if(myuser != null)
            {
                HttpContext.Session.SetString("usersession", myuser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.loginfaileddata = "Login failed...";
            }
                return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                HttpContext.Session.Remove("usersession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                ViewBag.logindata = HttpContext.Session.GetString("usersession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
                return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser= _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                if (existingUser == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    TempData["registered"] = "Registered sucessfully";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["alreadyregistered"] = "User already sucessfully";
                    return RedirectToAction("Login");
                }
            }
            return View(user);
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
