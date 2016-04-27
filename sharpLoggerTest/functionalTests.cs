using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using sharpLogger;
using sharpLogger.Handlers;

namespace sharpLoggerTest
{
    [TestClass]
    public class functionalTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            logger l = new logger("testingLogger.main");
            l.setLevel(loggerLevels.DEBUG);

            logger l2 = new logger("testingLogger.main2");
            l2.setLevel(loggerLevels.INFO);

            flexHandler h = new flexHandler(Console.WriteLine);
            h.setLevel(loggerLevels.DEBUG);

            flexHandler h2 = new flexHandler(Console.WriteLine);

            formatter f = new formatter("{levelName}:{name}:{message}");

            h.setFormatter(f);


            l.addHandler(h);

            l2.addHandler(h);
            l2.addHandler(h2);

            string testMessage = "testing this in a new Context {0}";
            string[] argsArray = new string[] { "testArgs1", "testArgs2" };

            l.debug(testMessage, argsArray);

            l.critical(testMessage, argsArray);

            l2.debug(testMessage, argsArray);

            l2.critical(testMessage, argsArray);

            Console.WriteLine("complete");

        }
    }
}
