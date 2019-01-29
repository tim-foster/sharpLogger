using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharpLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using sharpLogger.Handlers;


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

    [TestClass]
    public class noHandlers
    {
        [TestMethod]
        public void fire_critical_with_no_handler()
        {

            var l = new logger("no_handler");
            l.critical("");
        }
        
    }

    [TestClass]
    public class logger_critical
    {
        logger l;
        TextWriter stdOut = Console.Out;
        string testMessage;
        string testMessageResult;
        StringWriter consoleOut;

        string[] argsTest = new string[] { "test_args1", "test_args2" };

        [TestInitialize]
        public void setup()
        {
            l = new logger("logger_critical");
            l.setLevel(loggerLevels.CRITICAL);

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.ERROR);

            l.addHandler(h);

            testMessage = "Testing Logger {0}, {1}";

            testMessageResult = String.Format(testMessage, argsTest);

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            l.clearHandlers();
            l = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public async Task logger_critical_sendCritical()
        {
            await l.critical(testMessage, argsTest);

            Assert.AreEqual(testMessageResult + "\r\n", consoleOut.ToString());

        }

        [TestMethod]
        public async Task logger_critical_sendError()
        {

            await l.error(testMessage, argsTest);

            Assert.AreEqual("", consoleOut.ToString());

        }

        [TestMethod]
        public async Task logger_critical_sendWarning()
        {

            await l.warning(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public async Task logger_critical_sendInfo()
        {

            await l.info(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

        [TestMethod]
        public async Task logger_critical_SendDebug()
        {

            await l.debug(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), "");

        }

    }
    /*
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
    */
    [TestClass]
    public class logger_debug
    {
        logger l;
        TextWriter stdOut = Console.Out;
        string testMessage;
        string testMessageResult;
        StringWriter consoleOut;

        string[] argsTest = new string[] { "test_args1", "test_args2" };

        [TestInitialize]
        public void setup()
        {
            l = new logger("logger_debug");
            l.setLevel(loggerLevels.DEBUG);

            flexHandler h = new flexHandler();
            h.setLevel(loggerLevels.DEBUG);

            l.addHandler(h);

            testMessage = "Testing Logger {0}, {1}";

            testMessageResult = String.Format(testMessage, argsTest);

            consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
        }

        [TestCleanup]
        public void tearDown()
        {
            l.clearHandlers();
            l = null;
            Console.SetOut(stdOut);

        }

        [TestMethod]
        public async Task logger_debug_sendCritical()
        {
            await l.critical(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), testMessageResult + "\r\n");

        }

        [TestMethod]
        public async Task logger_debug_sendError()
        {

            await l.error(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), testMessageResult + "\r\n");

        }

        [TestMethod]
        public async Task logger_debug_sendWarning()
        {

            await l.warning(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), testMessageResult + "\r\n");

        }

        [TestMethod]
        public async Task logger_debug_sendInfo()
        {

            await l.info(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), testMessageResult + "\r\n");

        }

        [TestMethod]
        public async Task logger_debug_sendDebug()
        {

            await l.debug(testMessage, argsTest);

            Assert.AreEqual(consoleOut.ToString(), testMessageResult + "\r\n");

        }

    }
    
}