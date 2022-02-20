using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver
{
    [TestClass]
    [TestCategory("IntegerOperations")]
    public class IntegerOperations
    {
        static int number1;
        static int number2;
        [ClassInitialize]
        public static void IntegerInitialize(TestContext testContext)
        {
            number1 = 10;
            number2 = 5;
        }

        [TestMethod]
        public void Test_Addition()
        {
            int sum = number1 + number2;
            Console.WriteLine(sum);
            Assert.AreEqual(15, sum);
        }
        [TestMethod]
        public void Test_Substraction()
        {
            int difference = number1 - number2;
            Assert.AreEqual(5, difference);
        }
        [TestMethod]
        public void Test_Multiplication()
        {
            int multiplication = number1 * number2;
            Assert.AreEqual(50, multiplication);
        }
        [TestMethod]
        public void Test_Division()
        {
            int division = number1 / number2;
            Assert.AreEqual(2, division);
        }
        [TestMethod]
        public void Test_Modulus()
        {
            int remainder = number1 % number2;
            Assert.AreEqual(0, remainder);
        }
    }
}
