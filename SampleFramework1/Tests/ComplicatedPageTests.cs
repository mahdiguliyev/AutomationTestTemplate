using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework.Tests
{
    [TestClass]
    [TestCategory("ComplicatedPage")]
    public class ComplicatedPageTests : BaseTest
    {
        ComplicatedPage ComplicatedPage;
        [TestInitialize]
        public void OpenComplicatedPage()
        {
            ComplicatedPage = new ComplicatedPage(Driver);
            ComplicatedPage.GoTo();
            Assert.IsTrue(ComplicatedPage.IsLoaded, "The Complicated Page did not open.");
        }
        [TestMethod]
        [TestProperty("Author", "MahdiGuliyev")]
        public void TCID4()
        {
            ComplicatedPage.RandomStuffSection.FillOutFormAndSubmit("Mahdi", "mahdiguliyev@gmail.com", "I am a greate QA Engineer");
            Assert.IsTrue(ComplicatedPage.RandomStuffSection.IsFormSubmitted, "The form was not submitted successfully.");
        }
    }
}
