using NunitTestingProject;
//using NunitTestingProject.PropertyMapper;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var emp = setEmployee(false);
            var mapped = new PropertyMapper();
            mapped.SetEmployeeNationality(emp);
            Assert.That(emp.nationality,Is.EqualTo(Nationalities.Indian));
        }

        //to test multiple scenarios,instead of creating multiple test methods,create multiple testcases for same method
        [TestCase(true, Nationalities.Indian)]
        [TestCase(false, Nationalities.Undefined)]
        public void Test2(bool isIndian, Nationalities nationality)
        {
            var emp = setEmployee(isIndian);
            var mapped = new PropertyMapper();
            mapped.SetEmployeeNationality(emp);
            Assert.That(emp.nationality, Is.EqualTo(nationality));
        }


        private static Employee setEmployee(bool isIndian)
        {
            return new Employee
            {
                Id = 1,
                Name = "Aby",
                isIndian = isIndian,
            };
        }
    }
}