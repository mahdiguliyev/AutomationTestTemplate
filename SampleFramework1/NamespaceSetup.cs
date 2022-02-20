using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFramework.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleFramework
{
    [TestClass]
    public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Report.StartReporter();
        }
    }
}
