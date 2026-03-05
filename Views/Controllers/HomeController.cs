using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["data1"] = "morning";
            string[] arr = { "red", "blue", "purple" };
            ViewData["data2"] = arr;
            ViewData["data3"] = new List<string>
            { "cricket","football","hockey"};
            return View();
            //razor views are used for converting c# code into html from cshtml
            //viewdata needs type casting,works only for single request,throws error at runtime
        }

        public IActionResult About()
        {
            return View();
            //razor views are used for converting c# code into html from cshtml
        }
        public IActionResult Contact()
        {
            return View();
            //razor views are used for converting c# code into html from cshtml
        }
    }
}
