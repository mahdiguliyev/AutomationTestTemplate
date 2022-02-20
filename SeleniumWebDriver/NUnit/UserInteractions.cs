using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SeleniumWebDriver.NUnit
{
    public class UserInteractions
    {
        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;
        [Test]
        public void DragAndDropTest()
        {
            var driver = new ChromeDriver();
            var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement targetElement = driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = driver.FindElement(By.Id("draggable"));

            actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }
        [Test]
        public void DragAndDropTest2()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));

            var drag = _actions
                     .ClickAndHold(sourceElement)
                     .MoveToElement(targetElement)
                     .Release(targetElement)
                     .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }
        [Test]
        public void DragAndDropTest3()
        {
            _driver.Navigate().GoToUrl("https://www.pureexample.com/jquery-ui/basic-droppable.html");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            IWebElement targetElement = _driver.FindElement(By.XPath("//*[@class='squaredotted ui-droppable']"));
            IWebElement sourceElement = _driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));

            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            string result = _driver.FindElement(By.Id("info")).Text;

            Assert.AreEqual("dropped!", result);
        }
        [Test]
        public void ResizableTest1()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resizeHandle = _driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            _actions.ClickAndHold(resizeHandle).MoveByOffset(100, 100).Perform();

            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);
        }
        [Test]
        public void DragAndDropTestWithHTML5()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");
            var source = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("column-a")));

            var jsFile = File.ReadAllText(@"C:\Projects\SeleniumWebDriver\SeleniumWebDriver\JSHelpers\drag_and_drop_helper.js");
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            js.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");

            Assert.AreEqual("A", _driver.FindElement(By.XPath("//*[@id='column-b']/header")).Text);
        }
        [Test]
        public void DrawTest()
        {
            _driver.Navigate().GoToUrl("https://testpages.herokuapp.com/gui_user_interactions.html");
            _driver.Manage().Window.Maximize();

            _driver.FindElement(By.TagName("html")).Click();

            IWebElement canvas = _driver.FindElement(By.Id("canvas"));
            Debug.WriteLine($"canvas x: {canvas.Location.X}");
            Debug.WriteLine($"canvas y: {canvas.Location.Y}");

            var eventList = _driver.FindElement(By.Id("keyeventslist"));
            var li = eventList.FindElements(By.TagName("li"));
            var eventCount = li.Count;

            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random(i);
                var rnd2 = new Random(i + 3);

                var x = rnd2.Next(1, 100);
                var y = rnd.Next(1, 100);

                Debug.WriteLine($"canvas x: {canvas.Location.X - x}");
                Debug.WriteLine($"canvas y: {canvas.Location.Y - y}");

                _actions.DragAndDropToOffset(canvas, canvas.Location.X - x, canvas.Location.Y - y).Perform();
            }

            Assert.IsTrue(eventCount < eventList.FindElements(By.TagName("li")).Count);
        }
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        [TearDown]
        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
