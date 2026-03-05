using System.Diagnostics;
using DropDownSingle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DropDownSingle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _studentDBContext;
        public HomeController(ILogger<HomeController> logger, StudentDbContext studentDbContext)
        {
            _logger = logger;
            _studentDBContext = studentDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var studentData = await _studentDBContext.Student.ToListAsync();
            return View(studentData);
        }
        public IActionResult Create()
        {
            //List<SelectListItem> Gender = new List<SelectListItem>()
            //{
            //new SelectListItem {Value="Male",Text="Male"},
            //new SelectListItem {Value="Female",Text="Female" }
            //};
            ViewBag.Gender = Enum.GetValues(typeof(Students.Genders))
                .Cast<Students.Genders>()
                .Select(genders => new SelectListItem
                {
                    Value = ((int)genders).ToString(),
                    Text = genders.ToString()
                });
            //ViewBag.Gender = Enum.GetValues(typeof(Students.Genders)).Cast<Students.Genders>().ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Students student)
        {
            if (ModelState.IsValid)
            {
                await _studentDBContext.Student.AddAsync(student);//async and await is used because asp.net core recommends to use async and await
                await _studentDBContext.SaveChangesAsync();
                TempData["insertMsg"] = "Record inserted";//tempdata is used because we need this message to be seen only after one request
                return RedirectToAction("Index", "Home");
            }
            return View(student);//incase of errors we are passing student object so that we can see our passed data in url
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _studentDBContext.Student == null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Student.FirstOrDefaultAsync(x => x.Rollno == id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            //List<SelectListItem> Gender = new List<SelectListItem>()
            //{
            //new SelectListItem {Value="Male",Text="Male"},
            //new SelectListItem {Value="Female",Text="Female" }
            //};
            ViewBag.Gender = Enum.GetValues(typeof(Students.Genders))
              .Cast<Students.Genders>()
              .Select(genders => new SelectListItem
              {
                  Value = ((int)genders).ToString(),
                  Text = genders.ToString()
              });


            if (id == null || _studentDBContext.Student == null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Student.FindAsync(id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Students student)
        {
            if (id != student.Rollno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _studentDBContext.Student.Update(student);
                await _studentDBContext.SaveChangesAsync();
                TempData["updateMsg"] = "Record Updated";
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _studentDBContext.Student == null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Student.FirstOrDefaultAsync(x => x.Rollno == id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var studentData = await _studentDBContext.Student.FindAsync(id);
            if (studentData != null)
            {
                _studentDBContext.Student.Remove(studentData);
            }
            await _studentDBContext.SaveChangesAsync();
            TempData["DeleteMsg"] = "Record Deleted";
            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> DropDownWithDb()
        //{
        //    //var studentData = await _studentDBContext.Student.ToListAsync();
        //    var myModel = BindDDL();
        //    return View(myModel);

        //}
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
