using Microsoft.AspNetCore.Mvc;

namespace WebAppEmptyBasics.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
       
        public IActionResult Index()
        {
            return View();
        }
        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Home/Details/{id}")]//for option id use id?
        public int Details(int id)
        {
            return id;
        }

        [Route("Home/GetDetails/{id?}")]//for option id use id?
        public int GetDetails(int? id)
        {
            return id ?? 1;//if id is null then display 1
        }
       
        [Route("DataMethod")]//routes names can be anything,not copulsorily to have method name as a route
        [Route("Home/DataMethod")]
        public IActionResult Data()
        {
            return View("~/Views/Home/Index.cshtml");//no view is created for Data method hence we are using view of index method
        }
    }
}
