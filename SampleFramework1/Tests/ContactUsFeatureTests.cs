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
        [TestMethod]
        [Description("Validate that the sing in page opens successfully.")]
        [TestProperty("Author", "MahdiGuliyev")]
        public void TDID3()
        {
            CoursesPage coursesPage = new CoursesPage(Driver);
            coursesPage.Goto();
            var signInPage = coursesPage.ClickSignInButton();

            Assert.IsTrue(signInPage.IsLoaded, "Passing to Sign In page was not successfully.");
        }
        [TestMethod]
        [Description("Validate that form in the Complicated Page submit successfully.")]
        [TestProperty("Author", "MahdiGuliyev")]
        public void TDID4()
        {
            //1. open automation page with many items - https://ultimateqa.com/complicated-page/
            //2. Fill out and submit form in the "Section of random stuff"
            //3. validate that form was submitted successfully
        }

    }
}
