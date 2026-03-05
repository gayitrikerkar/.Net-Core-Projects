using System.Diagnostics;
using CodeFirstApproachCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDBContext _studentDBContext;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }
        public async Task <IActionResult> Index()
        {
            var studentData = await _studentDBContext.Students.ToListAsync();
            return View(studentData);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
               await _studentDBContext.Students.AddAsync(student);//async and await is used because asp.net core recommends to use async and await
               await _studentDBContext.SaveChangesAsync();
               TempData["insertMsg"] = "Record inserted";//tempdata is used because we need this message to be seen only after one request
               return RedirectToAction("Index","Home");
            }
            return View(student);//incase of errors we are passing student object so that we can see our passed data in url
        }


        public async Task<IActionResult> Details(int? id)
        {
            if(id== null || _studentDBContext.Students==null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.RollNo == id);
            if(studentData==null)
            {
                return NotFound();
            }
            return View(studentData);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentDBContext.Students == null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Students.FindAsync(id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student student)
        {
            if(id != student.RollNo)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _studentDBContext.Students.Update(student);
                await _studentDBContext.SaveChangesAsync();
                TempData["updateMsg"] = "Record Updated";
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _studentDBContext.Students == null)
            {
                return NotFound();
            }
            var studentData = await _studentDBContext.Students.FirstOrDefaultAsync(x => x.RollNo == id);
            if (studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var studentData = await _studentDBContext.Students.FindAsync(id);
            if(studentData != null)
            {
                _studentDBContext.Students.Remove(studentData);
            }
            await _studentDBContext.SaveChangesAsync();
            TempData["DeleteMsg"] = "Record Deleted";
            return RedirectToAction("Index", "Home");
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
