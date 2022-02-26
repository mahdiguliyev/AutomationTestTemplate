using AventStack.ExtentReports;
using OpenQA.Selenium;
using SampleFramework.PageParts;
using SampleFramework.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework.Pages
{
    public class ComplicatedPage : BasePage
    {
        public ComplicatedPage(IWebDriver driver) : base(driver) { }

        #region Elements

        #endregion

        #region Properties
        public RandomStuffSection RandomStuffSection => new RandomStuffSection(Driver);
        public bool IsLoaded
        {
            get
            {
                try
                {
                    var isLoaded = Driver.Url.Contains("complicated-page");
                    Report.LogTestStepForBugLogger(Status.Info, "Check whether the Complicated Page loaded successfully.");
                    return isLoaded;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        #endregion

        #region Methods

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/complicated-page/");
            Report.LogPassingTestStepForBugLogger($"Navigate to Complicated Page at url=>https://ultimateqa.com/complicated-page/");
        }

        #endregion
    }
}
