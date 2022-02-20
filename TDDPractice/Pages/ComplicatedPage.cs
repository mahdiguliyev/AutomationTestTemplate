using OpenQA.Selenium;
using System.Data;

namespace TDDPractice.Pages
{
    public class ComplicatedPage
    {
        public IWebDriver Driver { get; }
        public ComplicatedPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void Open()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/complicated-page/");
        }
        public void FillTheForm(string name, string email, string text)
        {
            var nameInput = Driver.FindElement(By.Id("et_pb_contact_name_0"));
            nameInput.SendKeys(name);
            var emailInput = Driver.FindElement(By.Id("et_pb_contact_email_0"));
            emailInput.SendKeys(email);
            var textArea = Driver.FindElement(By.Id("et_pb_contact_message_0"));
            textArea.SendKeys(text);

            var data = new DataTable();
            var computedText = Driver.FindElements(By.ClassName("et_pb_contact_captcha_question"))[0].Text;
            var result = data.Compute(computedText,"1");

            var resultInput = Driver.FindElements(By.XPath("//*[@class='input et_pb_contact_captcha']"))[0];
            resultInput.SendKeys(((int)result).ToString());

            var submit = Driver.FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[0];
            submit.Click();
        }
    }
}