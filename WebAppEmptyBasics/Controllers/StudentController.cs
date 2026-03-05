using Microsoft.AspNetCore.Mvc;

namespace WebAppEmptyBasics.Controllers
{
    [Route("[controller]")] //this is tolen which is like a placeholder which will get replaced with the controller name so that we dont need to specify the controller name everywhere.sam ething applies for action method
    public class StudentController : Controller
    {
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("[action]")]
        public IActionResult StudentABout()//IActionResult is implemented by many classes thus it can return many types of data such as view,json etc
        {
            return View();
        }//action methods must be public and cannot be static
    }
}
