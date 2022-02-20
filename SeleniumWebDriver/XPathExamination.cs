using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWebDriver
{
    [TestClass]
    public class XPathExamination
    {
        [TestMethod]
        public void ExamineXpath()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement radioButton = driver.FindElement(By.XPath("//*[@type='radio'][@value='female']"));
            radioButton.Click();
            IWebElement checkBox = driver.FindElement(By.XPath("//*[@name='vehicle'][@value='Car']"));
            checkBox.Click();
            IWebElement option = driver.FindElement(By.XPath("//*[@value='saab']"));
            option.Click();
            
            IWebElement tab2 = driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']"));
            Thread.Sleep(200);
            tab2.Click();

            Thread.Sleep(2000);

            string contentText = driver.FindElement(By.XPath("//div[@class='et_pb_tab et_pb_tab_1 clearfix et-pb-active-slide']/child::div")).Text;
            bool isDisplayedContentText = driver.FindElement(By.XPath("//div[@class='et_pb_tab et_pb_tab_1 clearfix et-pb-active-slide']/child::div")).Displayed;

            Assert.AreEqual("Tab 2 content", contentText);
            Assert.IsTrue(isDisplayedContentText);

            driver.Close();
            driver.Quit();
        }
    }
}
