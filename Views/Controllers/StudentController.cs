using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Views.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            TempData.Keep("data1");
            //tempdata need type casting
            //tempdata values can only be used for one request i.e if it is used in index page,it cannot be used in about page
            //unline viewdata and viewbag,tempdata is used to pass values from one method to different view i.e from index method to about view page
            //tempdat.keep mathod is used to maintain tempdata value throughout,just add tempdat.keep in all the methods.
            TempData["data1"] = "good";
            string[] arr = { "red", "blue", "purple" };
            TempData["data2"] = arr;
            TempData["data3"] = new List<string>
            { "cricket","football","hockey"};
            return View();
        }

        public IActionResult About()
        {
            TempData.Keep("data1");
            return View();
        }

        public IActionResult Contact()
        {
            TempData.Keep("data1");
            return View();
        }
    }
}
