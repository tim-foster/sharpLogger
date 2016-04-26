using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

using sharpLogger;
using sharpLogger.Handlers;

namespace sharpLoggerTest
{
    [TestClass]
    public class logRecord_constructorTest
    {
        string[] argsTest = new string[] { "test_args1", "test_args2" };
        [TestMethod]
        public void logRecord_constructorPopulatesCreated()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", argsTest, "");

            Assert.IsNotNull(b.created);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesMsecs()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", argsTest, "");

            Assert.AreEqual(b.created.Millisecond, b.msecs);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesLevelName()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL,"", argsTest, "");

            Assert.AreEqual("CRITICAL", b.levelName);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesLevelNo()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", argsTest, "");

            Assert.AreEqual(50, b.levelNo);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesProcessName()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", argsTest, "");

            Process tempProcess = Process.GetCurrentProcess();

            Assert.AreEqual(tempProcess.ProcessName, b.processName);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesProcessNo()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", argsTest, "");

            Process tempProcess = Process.GetCurrentProcess();

            Assert.AreEqual(tempProcess.Id, b.process);
        }
    }
}
