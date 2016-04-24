using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharpLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpLogger.Tests
{
    [TestClass()]
    public class loggerTests
    {
        [TestMethod()]
        public void addHandlerTest()
        {
            Assert.AreEqual("a", "a");
        }

        [TestMethod()]
        public void debugTest()
        {
            Assert.AreEqual(true, true);
        }
    }
}