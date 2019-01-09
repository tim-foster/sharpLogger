using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharpLogger;
using sharpLogger.Handlers;
using System.IO;

namespace sharpLoggerTest
{
    [TestClass]
    public class sharpLoggerTests
    {
        logger b = null;

        [TestInitialize]
        public void setup()
        {
            logging Logging = logging.Instance;
            b = Logging.getLogger("blahhh");
        }

        [TestCleanup]
        public void tearDown()
        {
            b = null;
        }

        [TestMethod]
        public void logger_getLoggerReturnsALogger()
        {
            Assert.AreEqual(b.GetType(), typeof(logger));
        }

        [TestMethod]
        public void logger_LevelDefaultsToNotSet()
        {
            Assert.AreEqual(b.getlevel(), loggerLevels.NOTSET);
        }

        [TestMethod]
        public void logger_setLevelToDebug()
        {
            b.setLevel(loggerLevels.DEBUG);

            Assert.AreEqual(b.getlevel(), loggerLevels.DEBUG);
        }

        [TestMethod]
        public void logger_changeLevelFromDebugToCritical()
        {

            b.setLevel(loggerLevels.DEBUG);

            Assert.AreEqual(b.getlevel(), loggerLevels.DEBUG);

            b.setLevel(loggerLevels.CRITICAL);

            Assert.AreEqual(b.getlevel(), loggerLevels.CRITICAL);
        }

        [TestMethod]
        public void logger_addHandler()
        {
            consoleHandler h = new consoleHandler();
            h.setLevel(loggerLevels.DEBUG);

            b.addHandler(h);

            Assert.AreEqual(b.Count, 1);
        }
    }

    [TestClass]
    public class loggerSendMessageTests
    {
        logger b_logger = null;

        [TestInitialize]
        public void setup()
        {
            logging Logging = logging.Instance;
            b_logger = Logging.getLogger(this);
        }

        [TestCleanup]
        public void tearDown()
        {
            b_logger.clearHandlers();
            b_logger = null;
        }

        [TestMethod]
        public void logger_sendDebug()
        {
            string testMessage = "this is a test";

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.DEBUG);

            b_logger.addHandler(h);

            StringWriter consoleOut = new StringWriter();

            Console.SetOut(consoleOut);

            b_logger.debug(testMessage);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");
        }

        [TestMethod]
        public void logger_sendDebugButLevelIsCritical()
        {
            string testMessage = "this is a test";

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.DEBUG);

            b_logger.addHandler(h);
            b_logger.setLevel(loggerLevels.CRITICAL);

            StringWriter consoleOut = new StringWriter();

            Console.SetOut(consoleOut);

            b_logger.debug(testMessage);

            Assert.AreEqual(consoleOut.ToString(), "");
        }

        [TestMethod]
        public void logger_sendDebugToCriticalhandler()
        {
            string testMessage = "this is a test";

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.CRITICAL);

            b_logger.addHandler(h);
            b_logger.setLevel(loggerLevels.DEBUG);

            StringWriter consoleOut = new StringWriter();

            Console.SetOut(consoleOut);

            b_logger.debug(testMessage);

            Assert.AreEqual(consoleOut.ToString(), "");
        }

        [TestMethod]
        public void logger_sendCriticalToCriticalhandler()
        {
            string testMessage = "this is a test";

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.CRITICAL);

            b_logger.addHandler(h);
            b_logger.setLevel(loggerLevels.DEBUG);

            StringWriter consoleOut = new StringWriter();

            Console.SetOut(consoleOut);

            b_logger.critical(testMessage);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");
        }

    }
}
