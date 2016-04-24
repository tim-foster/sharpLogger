using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using sharpLogger;
using sharpLogger.Handlers;

namespace sharpLoggerTest
{
    [TestClass]
    public class flexHandlerTests
    {
        flexHandler h;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
        }

        [TestMethod]
        public void flexHandler_levelDefaultToNotSet()
        {
            Assert.AreEqual(h.getlevel(), loggerLevels.NOTSET);
        }

        
    }

    [TestClass]
    public class flexHandlerCritical
    {
        flexHandler h;
        TextWriter stdOut = Console.Out;
        string testMessage;
        StringWriter consoleOut;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
            h.setLevel(loggerLevels.CRITICAL);

            testMessage = "Testing handler";

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public void flexHandler_critical_sendCritical()
        {
            h.log(testMessage, loggerLevels.CRITICAL);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_critical_sendError()
        {

            h.log(testMessage, loggerLevels.ERROR);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_critical_sendWarning()
        {

            h.log(testMessage, loggerLevels.WARNING);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_critical_sendInfo()
        {

            h.log(testMessage, loggerLevels.INFO);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_critical_SendDebug()
        {

            h.log(testMessage, loggerLevels.DEBUG);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_critical_sendNotSet()
        {

            h.log(testMessage, loggerLevels.NOTSET);

            Assert.AreEqual(consoleOut.ToString(), "");

        }
    }
    [TestClass]
    public class flexHandlerError
    {
        flexHandler h;
        TextWriter stdOut = Console.Out;
        string testMessage;
        StringWriter consoleOut;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
            h.setLevel(loggerLevels.ERROR);

            testMessage = "Testing handler";

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public void flexHandler_error_sendCritical()
        {
            h.log(testMessage, loggerLevels.CRITICAL);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_error_sendError()
        {

            h.log(testMessage, loggerLevels.ERROR);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_error_sendWarning()
        {

            h.log(testMessage, loggerLevels.WARNING);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_error_sendInfo()
        {

            h.log(testMessage, loggerLevels.INFO);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_error_sendDebug()
        {

            h.log(testMessage, loggerLevels.DEBUG);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_error_sendNotSet()
        {

            h.log(testMessage, loggerLevels.NOTSET);

            Assert.AreEqual(consoleOut.ToString(), "");

        }
    }
    [TestClass]
    public class flexHandlerWarning
    {
        flexHandler h;
        TextWriter stdOut = Console.Out;
        string testMessage;
        StringWriter consoleOut;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
            h.setLevel(loggerLevels.WARNING);

            testMessage = "Testing handler";

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public void flexHandler_warning_sendCritical()
        {
            h.log(testMessage, loggerLevels.CRITICAL);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_warning_sendError()
        {

            h.log(testMessage, loggerLevels.ERROR);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_warning_sendWarning()
        {

            h.log(testMessage, loggerLevels.WARNING);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_warning_sendInfo()
        {

            h.log(testMessage, loggerLevels.INFO);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_warning_sendDebug()
        {

            h.log(testMessage, loggerLevels.DEBUG);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_warning_sendNotSet()
        {

            h.log(testMessage, loggerLevels.NOTSET);

            Assert.AreEqual(consoleOut.ToString(), "");

        }
    }

    [TestClass]
    public class flexHandlerInfo
    {
        flexHandler h;
        TextWriter stdOut = Console.Out;
        string testMessage;
        StringWriter consoleOut;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
            h.setLevel(loggerLevels.INFO);

            testMessage = "Testing handler";

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
            Console.SetOut(stdOut);

        }


        [TestMethod]
        public void flexHandler_info_sendCritical()
        {
            h.log(testMessage, loggerLevels.CRITICAL);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_info_sendError()
        {

            h.log(testMessage, loggerLevels.ERROR);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_info_sendWarning()
        {

            h.log(testMessage, loggerLevels.WARNING);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_info_sendInfo()
        {

            h.log(testMessage, loggerLevels.INFO);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_info_sendDebug()
        {

            h.log(testMessage, loggerLevels.DEBUG);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public void flexHandler_info_sendNotSet()
        {

            h.log(testMessage, loggerLevels.NOTSET);

            Assert.AreEqual(consoleOut.ToString(), "");

        }
    }

    [TestClass]
    public class flexHandlerDebug
    {
        flexHandler h;
        TextWriter stdOut = Console.Out;
        string testMessage;
        StringWriter consoleOut;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
            h.setLevel(loggerLevels.DEBUG);

            testMessage = "Testing handler";

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public void flexHandler_debug_sendCritical()
        {
            h.log(testMessage, loggerLevels.CRITICAL);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_debug_sendError()
        {

            h.log(testMessage, loggerLevels.ERROR);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_debug_sendWarning()
        {

            h.log(testMessage, loggerLevels.WARNING);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_debug_sendInfo()
        {

            h.log(testMessage, loggerLevels.INFO);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_debug_sendDebug()
        {

            h.log(testMessage, loggerLevels.DEBUG);

            Assert.AreEqual(consoleOut.ToString(), testMessage + "\r\n");

        }

        [TestMethod]
        public void flexHandler_debug_sendNotSet()
        {

            h.log(testMessage, loggerLevels.NOTSET);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

    }

    [TestClass]
    public class flexHandlerNotSet
    {
        flexHandler h;

        [TestInitialize]
        public void setup()
        {
            h = new flexHandler();
        }

        [TestCleanup]
        public void tearDown()
        {
            h = null;
        }
    }
}
