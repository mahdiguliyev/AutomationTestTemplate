using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SampleFramework.Pages;
using SampleFramework.Reporter;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SampleFramework.PageParts
{
    public class RandomStuffSection : BasePage
    {
        public RandomStuffSection(IWebDriver driver) : base(driver) { }

        #region Properties

        public bool IsFormSubmitted
        {
            get
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                try
                {
                    var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
                    var isSubmitted = element.Text.Contains("Thanks for contacting us");
                    if(isSubmitted == false)
                    {
                        Report.LogTestStepForBugLogger(Status.Fail, "Validate that the form was submitted successfully.");
                        return false;
                    }
                    Report.LogTestStepForBugLogger(Status.Pass, "Validate that the form was submitted successfully.");
                    return isSubmitted;
                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }
            }
        }

        #endregion

        #region Methods

        public void FillOutFormAndSubmit(string name, string email, string message)
        {
            Driver.FindElement(By.Id("et_pb_contact_name_0")).SendKeys(name);
            Driver.FindElement(By.Id("et_pb_contact_email_0")).SendKeys(email);
            Driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys(message);

            string captchaPuzzle = Driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text;
            var splitedText = captchaPuzzle.Split(' ');
            int result = int.Parse(splitedText[0]) + int.Parse(splitedText[2]);

            IWebElement captcha = Driver.FindElements(By.XPath(@"//*[@class='input et_pb_contact_captcha']"))[0];
            captcha.SendKeys(result.ToString());
            IWebElement submitButton = Driver.FindElements(By.XPath(@"//*[@class='et_pb_contact_submit et_pb_button']"))[0];
            Thread.Sleep(1000);
            submitButton.Click();

            Report.LogPassingTestStepForBugLogger("Fill out the form in the Random Stuff section. " +
                $"Name=>{name}. Email=>{email}. Message=>{message}.");
        }

        #endregion
    }
}
