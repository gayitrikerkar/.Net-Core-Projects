using Microsoft.AspNetCore.Mvc;
using SampleMVCWithoutDb.Controllers;

namespace TestProject1
{
    public class Tests
    {
        private EmployeeController employeeController;
        [SetUp]
        public void Setup()
        {
           employeeController = new EmployeeController();
        }
        [TearDown]
        public void Teardown()
        {
            // Dispose of the controller after each test
            employeeController?.Dispose();
        }

        [Test]
        public void Test1()
        {
            employeeController.Index();
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            employeeController.GetEmployee(2);
            Assert.Pass();
        }
    }
}