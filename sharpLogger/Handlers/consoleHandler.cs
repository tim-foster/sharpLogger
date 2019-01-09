using System;
using System.Collections.Generic;
using System.Text;

namespace sharpLogger.Handlers
{
    public class consoleHandler : baseHandler
    {
        private Action<string> logAction = null;
        public override bool log(logRecord record)
        {
            if (this.getlevel() <= record.levelEnum)
            {

                this.logAction(this.formatter.format(record));
                return true;
            }
            return false;
        }

        public override bool log(string message_in, loggerLevels level_in)
        {
            if (this.getlevel() <= level_in)
            {
                this.logAction(message_in);
                return true;
            }
            return false;
        }

        public override void emit(logRecord record)
        {
            string msg = this.format(record);

        }

        public consoleHandler()
        {
            this.logAction = Console.WriteLine;
            formatter = _defaultFormatter;
        }
    }
}
