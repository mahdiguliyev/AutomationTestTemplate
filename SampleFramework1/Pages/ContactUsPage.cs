using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleFramework.Reporter;

namespace SampleFramework.Pages
{
    public class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement CenterColumn => Driver.FindElement(By.Id("center_column"));

        #endregion

        #region Properties
        private string PageTitle => "Contact us - My Store";
        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            private set { }
        }
        public bool IsLoaded
        {
            get
            {
                try
                {
                    Report.LogTestStepForBugLogger(Status.Info, "Validate that Contact Us page loaded successfully.");
                    return CenterColumn.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        #endregion

        #region Methods
        public void Goto()
        {
            var url = "http://automationpractice.com/index.php?controller=contact";
            Driver.Navigate().GoToUrl(url);
            Report.LogPassingTestStepForBugLogger($"Open url=>{url} for Contact Us page");
            Assert.IsTrue(IsVisible,
                $"Sample Application page was not visible. Expected => {PageTitle} " +
                $"Actual => {Driver.Title}");
        }
        #endregion
    }
}
