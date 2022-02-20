using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using SampleFramework.PageParts;

namespace SampleFramework.Pages
{
    public class HomePage : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public HomePage(IWebDriver driver) : base(driver) 
        {
            Slider = new Slider(driver);
        }

        #region Properties

        private string PageTitle => "My Store";
        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            private set { }
        }

        public Slider Slider { get; set; }

        #endregion

        #region Methods

        public void Goto()
        {
            var url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(url);
            Assert.IsTrue(IsVisible,
                $"Home Page was not visible. Expected => {PageTitle} " +
                $"Actual => {Driver.Title}");
            _logger.Info($"Open url => {url}");
        }

        #endregion
    }
}
