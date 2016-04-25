using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using sharpLogger;

namespace sharpLoggerTest
{
    [TestClass]
    public class formatter_constructorTests
    {
        [TestMethod]
        public void formatter_testDefaultConstructor()
        {
            formatter b = new formatter();
            logRecord l = new logRecord("testLogger", loggerLevels.CRITICAL, "testMessage", "", "");

            Console.WriteLine(b.format(l));
            Assert.AreEqual("testMessage", b.format(l));
        }
    }
}
