using OpenQA.Selenium;
using SampleFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework.PageParts
{
    public class Slider : BasePage
    {
        public Slider(IWebDriver driver) : base(driver) { }

        #region Properties

        public string CurrentImage => MainSliderImage.GetAttribute("style");
        private IWebElement NextButton => Driver.FindElement(By.ClassName("bx-next"));
        private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));
 
        #endregion

        #region Methods

        public void ClickNextButton()
        {
            NextButton.Click();
        }

        #endregion
    }
}
