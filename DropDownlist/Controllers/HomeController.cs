using System.Diagnostics;
using DropDownlist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DropDownlist.Controllers
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
            ModelState.Remove("studentList");
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
            ModelState.Remove("studentList");
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

        public IActionResult DropDownWithDb()
        {
            //var studentData = await _studentDBContext.Student.ToListAsync();
            var myModel = BindDDL();           
            return View(myModel);
            
        }

        [HttpPost]
        public IActionResult DropDownWithDb(merge myModel)
        {
            var studentData =  _studentDBContext.Student.Where(x => x.Rollno == myModel.s.Rollno).FirstOrDefault();
            var cityData = _studentDBContext.city.Where(x => x.CityId == myModel.c.CityId).FirstOrDefault();
            if (studentData != null && cityData!=null)
            {
                StudentCity studentcity = new StudentCity();
                studentcity.Rollno= studentData.Rollno;
                studentcity.CityId = cityData.CityId;
                _studentDBContext.studentcity.Add(studentcity);
                _studentDBContext.SaveChanges();
                ViewBag.selectedStudent = studentData.name;
                ViewBag.selectedCity = cityData.CityName;
            }
            else
            {
                ViewBag.invalidvalue = "Please select a value from the drop down list";
            }
                var mystudentModel = BindDDL();
            return View(mystudentModel);
        }

        //private StudentModel BindDDL()
        //{
        //    StudentModel stdModel = new StudentModel();
        //    stdModel.studentList = new List<SelectListItem>();
        //    var data = _studentDBContext.Student.ToList();
        //    stdModel.studentList.Add(new SelectListItem
        //    {
        //        Text = "Select Name",
        //        Value = ""
        //    });
        //    foreach (var item in data)
        //    {
        //        stdModel.studentList.Add(new SelectListItem
        //        {
        //            Text = item.name,
        //            Value = item.Rollno.ToString()
        //        });
        //    }
        //    //CityModel cityModel = new CityModel();
        //    stdModel.cityList = new List<SelectListItem>();
        //    var dataCity = _studentDBContext.city.ToList();
        //    stdModel.cityList.Add(new SelectListItem
        //    {
        //        Text = "Select Name",
        //        Value = ""
        //    });
        //    foreach (var item in dataCity)
        //    {
        //        stdModel.cityList.Add(new SelectListItem
        //        {
        //            Text = item.CityName,
        //            Value = item.CityId.ToString()
        //        });
        //    }
        //    return stdModel;
        //}
        private merge BindDDL()
        {
            //merge m= new merge();
            Students stdModel = new Students();
            stdModel.studentList = new List<SelectListItem>();
            var data = _studentDBContext.Student.ToList();
            stdModel.studentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });
            foreach (var item in data)
            {
                stdModel.studentList.Add(new SelectListItem
                {
                    Text = item.name,
                    Value = item.Rollno.ToString()
                });
            }
            City cityModel = new City();
            cityModel.cityList = new List<SelectListItem>();
            var dataCity = _studentDBContext.city.ToList();
            cityModel.cityList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });
            foreach (var item in dataCity)
            {
                cityModel.cityList.Add(new SelectListItem
                {
                    Text = item.CityName,
                    Value = item.CityId.ToString()
                });
            }
            var m = new merge
            {
                s = stdModel,
                c = cityModel
            };
            return m;
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
