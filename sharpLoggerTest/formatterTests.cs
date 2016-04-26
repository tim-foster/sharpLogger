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
            string testMessage = "testLogger {0}, {1}";
            string[] argsArray = new string[] { "test_args1", "test_args2" };
            formatter b = new formatter();
            logRecord l = new logRecord("formatter Test", loggerLevels.CRITICAL, testMessage, argsArray, "");

            Console.WriteLine(b.format(l));
            Assert.AreEqual(String.Format(testMessage, argsArray), b.format(l));
        }

        [TestMethod]
        public void formatter_properlyAddsLoggerName()
        {
            string testMessage = "testLogger {0}, {1}";
            string[] argsArray = new string[] { "test_args1", "test_args2" };
            loggerLevels testLevel = loggerLevels.CRITICAL;
            string loggerName = "formatter Test";

            formatter b = new formatter("{levelName}:{name}:{message}");
            logRecord l = new logRecord(loggerName, testLevel, testMessage, argsArray, "");

            string resultMessage = String.Format("{0}:{1}:{2}", testLevel, loggerName, String.Format(testMessage, argsArray));

            Console.WriteLine(b.format(l));
            Assert.AreEqual(resultMessage, b.format(l));
        }
    }
}
