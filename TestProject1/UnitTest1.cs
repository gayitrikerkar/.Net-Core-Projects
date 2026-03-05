using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

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
            //Assert.Pass();
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.Name("q"));
            webElement.SendKeys("selenium");
            webElement.SendKeys(Keys.Return);
        }

        [Test]
        public void Test2()
        {
            //Assert.Pass();
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost/EmployeeTestApp/Employees/Create");
            driver.Manage().Window.Maximize();
            IWebElement nameElement = driver.FindElement(By.Name("Name"));
            nameElement.SendKeys("Myola Dias");
            IWebElement desgElement2 = driver.FindElement(By.Name("Designation"));
            desgElement2.SendKeys("Engineer9");
            IWebElement btnCreate = driver.FindElement(By.CssSelector(".btn"));
            btnCreate.Submit();
        }

        [Test]
        public void Test3()
        {
            //Assert.Pass();
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost/EmployeeTestApp/");
            driver.Manage().Window.Maximize();
            IWebElement linkElement = driver.FindElement(By.LinkText("Create New"));
            linkElement.Click();           
        }

        [Test]
        public void Test4()
        {
            //Assert.Pass();
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://localhost/DropDownlist");
            driver.Manage().Window.Maximize();
            IWebElement linkElement = driver.FindElement(By.LinkText("Edit"));
            linkElement.Click();
        }
    }
}