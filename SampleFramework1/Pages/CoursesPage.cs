using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleFramework.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework.Pages
{
    public class CoursesPage : BasePage
    {
        public CoursesPage(IWebDriver driver) : base(driver) { }


        #region Elements
        private IWebElement CoursesSection => Driver.FindElement(By.ClassName("collections__content"));
        private IWebElement SignInButton => Driver.FindElements(By.XPath("//a[@href='/users/sign_in']"))[0];
        #endregion

        #region Properties
        private bool IsLoaded
        {
            get
            {
                try
                {
                    Report.LogTestStepForBugLogger(Status.Info, "Validate that Courses Page loaded successfully.");
                    return CoursesSection.Displayed;
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
            string url = "https://courses.ultimateqa.com/collections";
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Report.LogPassingTestStepForBugLogger($"Open url=> {url} for Courses Page");
            Assert.IsTrue(IsLoaded, "Courses Page was not loaded successfully.");
        }
        public SignInPage ClickSignInButton()
        {
            SignInButton.Click();
            Report.LogPassingTestStepForBugLogger("Sign in button is clicked.");

            return new SignInPage(Driver);
        }
        #endregion
    }
}
