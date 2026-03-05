using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Represents a simple Index method.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Represents a simple Products method.
        /// </summary>
        public IActionResult Products()
        {
            List<Products> productList = new List<Products>()
            {
                new Products()
                {
                    Id = 1,Name="Scenary",Description="Scenary picture from the computer",Price=150,Image="~/Images/one.png"
                },
                new Products()
                {
                    Id = 2,Name="Dog Frame",Description="Dog picture",Price=750,Image="~/Images/two.png"
                },
                new Products()
                {
                    Id = 3,Name="Horse Frame",Description="Horse picture frame",Price=550,Image="~/Images/three.png"
                }
            };
            return View(productList);
        }/// <summary>
/// Gets the username associated with the specified ID.
/// </summary>
/// <param name="id">The unique user ID.</param>
/// <returns>A string containing the username for the specified ID.</returns>
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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
