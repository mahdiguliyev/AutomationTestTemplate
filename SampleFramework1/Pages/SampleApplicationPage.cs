using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleFramework.Models;

namespace SampleFramework.Pages
{
    public class SampleApplicationPage : BasePage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        #region Properties
        private string PageTitle => "Sample Application Lifecycle - Sprint 4 | Ultimate QA";
        public bool IsVisible { 
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            private set { } }
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='submitForm']"));
        public IWebElement SubmitButton2 => Driver.FindElements(By.XPath("//*[@type='submit']"))[0];
        public IWebElement SubmitEmegencyContactFormButton => Driver.FindElement(By.Id("submit2"));
        public IWebElement MaleRadioButton => Driver.FindElement(By.XPath("//input[@value='male']"));
        public IWebElement FemaleRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement OtherRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));

        public IWebElement MaleForEmergencyContactRadioButton => Driver.FindElement(By.Id("radio2-m"));
        public IWebElement FemaleForEmergencyContactRadioButton => Driver.FindElement(By.Id("radio2-f"));
        public IWebElement OtherForEmergencyContactRadioButton => Driver.FindElement(By.Id("radio2-0"));
        public IWebElement FirstNameForEmergencyContacField => Driver.FindElement(By.Id("f2"));
        public IWebElement LastNameForEmergencyContacField => Driver.FindElement(By.Id("l2"));
        #endregion

        #region Methods

        public void Goto()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible, 
                $"Sample Application page was not visible. Expected => {PageTitle} " + 
                $"Actual => {Driver.Title}");
        }
        private void ChooseGender(UserModel user)
        {
            switch (user.Gender)
            {
                case GenderEnum.Male:
                    MaleRadioButton.Click();
                    break;
                case GenderEnum.Female:
                    FemaleRadioButton.Click();
                    break;
                case GenderEnum.Other:
                    OtherRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
        public UltimateQAHomePage FillOutPrimaryOrEmergencyForm(UserModel user, string formType = null)
        {
            if (formType == "emergency")
            {
                ChooseGenderForEmergencyContact(user);
                FirstNameForEmergencyContacField.SendKeys(user.FirstName);
                LastNameForEmergencyContacField.SendKeys(user.LastName);
                SubmitEmegencyContactFormButton.Click();

                return new UltimateQAHomePage(Driver);
            }

            ChooseGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton2.Submit();

            return new UltimateQAHomePage(Driver);
        }
        private void ChooseGenderForEmergencyContact(UserModel emergencyContactUser)
        {
            switch (emergencyContactUser.Gender)
            {
                case GenderEnum.Male:
                    MaleForEmergencyContactRadioButton.Click();
                    break;
                case GenderEnum.Female:
                    FemaleForEmergencyContactRadioButton.Click();
                    break;
                case GenderEnum.Other:
                    OtherForEmergencyContactRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
