using Microsoft.AspNetCore.Mvc;

namespace WebAppEmptyBasics.Controllers
{
    [Route("User")]//to avoid repeatation of controller name at every route,we are specifying it at the top level so every time the route for the action will be concetenated with this top level route for eg User/Index
    public class UserController : Controller
    {
        [Route("Index")]
       
        public IActionResult Index()
        {
            return View();
        }
        [Route("UserAbout")]
        public IActionResult UserAbout()
        {
            return View();
        }
    }
}
