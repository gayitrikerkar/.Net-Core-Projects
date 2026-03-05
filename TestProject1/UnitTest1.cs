using CodeFirstApproachCRUD.Controllers;
using NUnit.Framework.Api;

namespace TestProject1
{
    public class Tests
    {
        HomeController controller;
        [SetUp]
        public void Setup()
        {
            controller = new HomeController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}