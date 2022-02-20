using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleFramework.Models;
using SampleFramework.Pages;

namespace SampleFramework.Tests
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }
        private UserModel User { get; set; }
        private SampleApplicationPage SampleApplicationPage { get; set; }
        
        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        [TestProperty("Author","MahdiGuliyev")]
        public void Test1()
        {
            User.Gender = GenderEnum.Female;
            SampleApplicationPage.Goto();
            var ultimateQAHomePage = SampleApplicationPage.FillOutPrimaryOrEmergencyForm(User);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible!");
        }
        [TestMethod]
        [TestProperty("Author", "MahdiGuliyev")]
        public void Test2()
        {
            SampleApplicationPage.Goto();
            //Assert.IsTrue(SampleApplicationPage.IsVisible, "Sample Application page was not visible!");
            var ultimateQAHomePage = SampleApplicationPage.FillOutPrimaryOrEmergencyForm(User);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible!");
        }
        [TestMethod]
        [TestProperty("Author", "MahdiGuliyev")]
        [Description("Validate that when selecting the other gender type, the form is submitted successfully.")]
        public void Test3()
        {
            User.Gender = GenderEnum.Other;
            SampleApplicationPage.Goto();
            var ultimateQAHomePage = SampleApplicationPage.FillOutPrimaryOrEmergencyForm(User);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible!");
        }
        [TestMethod]
        [Description("Validate that user is able to fill out the primary form and emergency contact form.")]
        public void Test4()
        {
            User.Gender = GenderEnum.Female;
            SampleApplicationPage.Goto();
            var ultimateQAHomePage = SampleApplicationPage.FillOutPrimaryOrEmergencyForm(User, "emergency");
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible!");
        }
        [TestInitialize]
        public void Setup()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            SampleApplicationPage = new SampleApplicationPage(Driver);
            User = new UserModel { FirstName = "Mahdi", LastName = "Guliyev" };
        }
        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        
    }
}
