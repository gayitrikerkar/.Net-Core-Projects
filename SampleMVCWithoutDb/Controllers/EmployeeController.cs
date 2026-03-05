using Microsoft.AspNetCore.Mvc;
using SampleMVCWithoutDb.Models;

namespace SampleMVCWithoutDb.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }
        public IActionResult Index()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee() {   Id = 1,
                Name = "Aby",
                Age = 28,
                City = "Mapusa"},
                 new Employee() {   Id = 2,
                Name = "Siyu",
                Age = 24,
                City = "Bicholim"},
                new Employee() {   Id = 3,
                Name = "Cany",
                Age = 29,
                City = "Panjim"},
                 new Employee() {   Id = 4,
                Name = "Ely",
                Age = 31,
                City = "Mapusa"},
                 new Employee() {   Id = 5,
                Name = "Fio",
                Age = 19,
                City = "Valpoi"},


            };
            return View(emp);
        }

        public IActionResult GetEmployee(int empId)
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee() {   Id = 1,
                Name = "Aby",
                Age = 28,
                City = "Mapusa"},
                 new Employee() {   Id = 2,
                Name = "Siyu",
                Age = 24,
                City = "Bicholim"},
                new Employee() {   Id = 3,
                Name = "Cany",
                Age = 29,
                City = "Panjim"},
                 new Employee() {   Id = 4,
                Name = "Ely",
                Age = 31,
                City = "Mapusa"},
                 new Employee() {   Id = 5,
                Name = "Fio",
                Age = 19,
                City = "Valpoi"},


            };
            var empDetails= emp.Where(x=>x.Id == empId).ToList();
            return View();
        }
    }
}