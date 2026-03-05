using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.data1 = "morning";
            string[] arr = { "red", "blue", "purple" };
            ViewBag.data2 = arr;
            ViewBag.data3 = new List<string>
            { "cricket","football","hockey"};
            //viewdata and viewbag can be used interchangeabily
            ViewData["data4"] = "Hello";
            ViewBag.data5= "?world";
            //viewbag doesnt need type casting and it thrwos error at run time
            return View();
        }
    }
}
