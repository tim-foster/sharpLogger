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
        [TestMethod]
        public void logRecord_constructorPopulatesCreated()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", "", "");

            Assert.IsNotNull(b.created);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesMsecs()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", "", "");

            Assert.AreEqual(b.created.Millisecond, b.msecs);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesLevelName()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL,"","","");

            Assert.AreEqual("CRITICAL", b.levelName);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesLevelNo()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", "", "");

            Assert.AreEqual(50, b.levelNo);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesProcessName()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", "", "");

            Process tempProcess = Process.GetCurrentProcess();

            Assert.AreEqual(tempProcess.ProcessName, b.processName);
        }

        [TestMethod]
        public void logRecord_constructorPopulatesProcessNo()
        {
            logRecord b = new logRecord("test", loggerLevels.CRITICAL, "", "", "");

            Process tempProcess = Process.GetCurrentProcess();

            Assert.AreEqual(tempProcess.Id, b.process);
        }
    }
}
