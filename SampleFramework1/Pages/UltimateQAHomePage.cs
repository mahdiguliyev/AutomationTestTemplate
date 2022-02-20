using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SampleFramework.Pages
{
    public class UltimateQAHomePage : BasePage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        #region Properties
        //public IWebElement HomePageText => Driver.FindElement(By.XPath("//h1/span[contains(text(),'Master test Automation, Faster.')]"));
        public bool IsVisible
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    IWebElement HomePageText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1/span[contains(text(),'Master test Automation, Faster.')]")));
                    return HomePageText.Displayed;
                }
                catch (NoSuchElementException)
                {

                    return false;
                }
                
            }
        }
        #endregion
    }
}
