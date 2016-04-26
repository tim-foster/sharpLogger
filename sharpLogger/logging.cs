using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace sharpLogger
{
    public sealed class logging
    {
        private static readonly logging instance = new logging();

        private Dictionary<string, logger> loggerDictionary = new Dictionary<string, logger>();

        static logging()
        {

        }
        private logging()
        {

        }
        public static logging Instance
        {
            get
            {
                return instance;
            }
        }
        public logger getLogger()
        {
            return findLogger("root");

        }
        public logger getLogger(dynamic sender)
        {
            return findLogger(sender.GetType().Namespace);
        }
        public logger getLogger(string loggerName)
        {
            return findLogger(loggerName);
        }

        private logger findLogger(string name_in)
        {
            logger b_logger;
            if (!loggerDictionary.TryGetValue(name_in, out b_logger))
            {
                b_logger = new logger(name_in);
                loggerDictionary.Add(name_in, b_logger);
            }
            return b_logger;
        }
    }
}
