using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver
{
    [TestClass]
    [TestCategory("FloatingPointOperations")]
    public class FloatingPointOperations
    {
        static double number1;
        static double number2;
        [ClassInitialize]
        public static void IntegerInitialize(TestContext testContext)
        {
            number1 = 10.5;
            number2 = 5.0;
        }

        [TestMethod]
        public void Test_Addition()
        {
            double sum = number1 + number2;
            Console.WriteLine(sum);
            Assert.AreEqual(15.5, sum);
        }
        [TestMethod]
        public void Test_Substraction()
        {
            double difference = number1 - number2;
            Assert.AreEqual(5.5, difference);
        }
        [TestMethod]
        public void Test_Multiplication()
        {
            double multiplication = number1 * number2;
            Assert.AreEqual(52.5, multiplication);
        }
        [TestMethod]
        public void Test_Division()
        {
            double division = number1 / number2;
            Assert.AreEqual(2.1, division);
        }
        [TestMethod]
        public void Test_Modulus()
        {
            double remainder = number1 % number2;
            Assert.AreEqual(0.5, remainder);
        }
    }
}
