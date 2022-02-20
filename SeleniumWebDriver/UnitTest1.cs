using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SeleniumWebDriver
{
    [TestClass]
    [TestCategory("Case1")]
    public class UnitTest1
    {
        private int a;
        public TestContext Test3Context { get; set; }
        private static TestContext _testContext;
        [TestInitialize] // run this method every single test
        public void RunBeforeEveryTest()
        {
            a = 15;
        }
        [TestCleanup]
        public void RunAfterEveryTest()
        {
            Trace.Write("RunAfterEveryTest will execute after every single test method in a class");
        }
        [ClassInitialize]
        public void RunBeforeAllOfTheTestMethodsStarted(TestContext testContext)
        {
            _testContext = testContext;
            Trace.Write("I will run one time before all the tests in the class started");
        }
        [ClassCleanup]
        public void RunAfterAllOfTheTestMethodsFinished()
        {
            Trace.Write("I will run one time before all the tests in the class finished");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [Description("Sum of two numerical variables")]
        public void TestMethod1()
        {
            Assert.AreEqual(15, a);
        }
        [TestMethod]
        [TestCategory("Negative")]
        public void TestMethod2()
        {
            Assert.IsTrue(a == 10);
        }
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void TestMethod3()
        {
            Assert.AreNotEqual(10, a);
        }
    }

    [TestClass]
    [TestCategory("Case2")]
    public class Quiz
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(2, 1 + 1);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.Fail("Failed test!");
        }
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Test3()
        {
            Assert.AreEqual(21, 10 + 10);
        }
    }
}
