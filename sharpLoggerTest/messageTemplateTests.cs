using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharpLogger;
using sharpLogger.Handlers;

namespace sharpLoggerTest
{
    [TestClass]
    public class messageTemplateTests
    {

        [TestMethod]
        public void basicMessageTemplate()
        {
            StringWriter consoleOut = new StringWriter();

            Console.SetOut(consoleOut);
            string jobName = "test";
            DateTime runDate = DateTime.Today;
            logger log = logging.Instance.getLogger("messageTemplate");

                
            var h = new consoleHandler();

            h.setFormatter(new formatter("{levelName}:{message}"));


            log.addHandler(h);

            log = logging.Instance.getLogger("messageTemplate").ApplyMessageTemplate($"{jobName}: {runDate:yyyy-MM-dd}: {{message}}");

            log.info("test something");

            Assert.AreEqual($"INFO:{jobName}: {runDate:yyyy-MM-dd}: test something\r\n", consoleOut.ToString());
        }
    }
}
