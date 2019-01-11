using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharpLogger.Handlers
{
    public class flexHandler : baseHandler
    {
        delegate void logDelegate(string msg, loggerLevels lvl = loggerLevels.NOTSET);
        private logDelegate logAction = null;

        public override bool log(logRecord record)
        {
            if (this.getlevel() <= record.levelEnum)
            {

                this.logAction(this.formatter.format(record), record.levelEnum);
                return true;
            }
            return false;
        }

        public override bool log(string message_in, loggerLevels level_in)
        {
            if (this.getlevel() <= level_in)
            {
                this.logAction(message_in, level_in);
                return true;
            }
            return false;
        }

        public override void emit(logRecord record)
        {
            string msg = this.format(record);

        }
        
        public flexHandler()
        {
            this.logAction = (msg,level) => Console.WriteLine(msg);
            formatter = _defaultFormatter;
        }

        public flexHandler(Action<string> logAction_in)
        {
            this.logAction = (msg, level) => logAction_in(msg);
            formatter = _defaultFormatter;
        }

        public flexHandler(Action<string, loggerLevels> logAction_in)
        {
            this.logAction = (msg, level) => logAction_in(msg, level);
            formatter = _defaultFormatter;
        }
    }
}
