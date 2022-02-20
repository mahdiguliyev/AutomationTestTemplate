using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SampleFramework.Models;
using System;

namespace SampleFramework
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists!");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver();
        }
    }
}
