using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver
{
    [TestClass]
    [TestCategory("Math Tests")]
    public class MathTest
    {
        [TestMethod]
        public void SquareTest()
        {
            int result = MathHelper.Square(6);
            Assert.AreEqual(36, result);
        }
    }
}
