using AventStack.ExtentReports;
using OpenQA.Selenium;
using SampleFramework.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement WelcomeBackHeading => Driver.FindElement(By.ClassName("page__heading"));

        #endregion

        #region Properties

        public bool IsLoaded
        {
            get
            {
                try
                {
                    //var isloaded = Driver.Url.Contains("controller=authentication");
                    Report.LogTestStepForBugLogger(Status.Info, "Validate that Sign In Page loaded successfully.");
                    return WelcomeBackHeading.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                    throw;
                }
            }
        }

        #endregion

        #region Methods

        public void Goto()
        {

        }

        #endregion
    }
}
