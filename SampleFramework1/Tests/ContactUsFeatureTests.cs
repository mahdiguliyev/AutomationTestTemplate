using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFramework.Pages;

namespace SampleFramework.Tests
{
    [TestClass]
    [TestCategory("ContactUsPage")]
    public class ContactUsFeatureTests : BaseTest
    {
        [TestMethod]
        [Description("Validate that the contact us page opens successfully with a form.")]
        [TestProperty("Author","MahdiGuliyev")]
        public void TCID1()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.Goto();
            Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully!");
        }
        [TestMethod]
        [Description("Validate that slider changes images.")]
        [TestProperty("Author", "MahdiGuliyev")]
        public void TCID2()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.Goto();
            var oldImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            var newImage = homePage.Slider.CurrentImage;

            Assert.AreNotEqual(newImage, oldImage, "The slider images did not change when pressing the next button!");
        }
    }
}
