using System.Diagnostics;
using DbFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbFirstContext _DbFirstContext;

        public HomeController(ILogger<HomeController> logger, DbFirstContext dbFirstContext)
        {
            _logger = logger;
            _DbFirstContext = dbFirstContext;
        }

        public async Task<IActionResult> Index()
        {
            var empData = await _DbFirstContext.Employees.ToListAsync();
            return View(empData);
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
