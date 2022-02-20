using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Inharitance
{
    [TestClass]
    [TestCategory("Human Tests")]
    public class HumanTests
    {
        [TestMethod]
        public void InitialHumanDefine()
        {
            BackEndDeveloper backEndDeveloper = new BackEndDeveloper(2.5, 3, "Mahdi", "Guliyev", 24, 1.75, "Back-End Developer");
            Console.WriteLine(backEndDeveloper);
        }
    }
}
