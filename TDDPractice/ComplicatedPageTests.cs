using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TDDPractice.Pages;

namespace TDDPractice
{
    [TestClass]
    [TestCategory("TDD Practice")]
    public class ComplicatedPageTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = new ChromeDriver();

            var complicatedPage = new ComplicatedPage(driver);
            complicatedPage.Open();
            complicatedPage.FillTheForm(name: "Mahdi",email: "testemail@gmail.com",text: "Hello everyone");
        }
    }
}
