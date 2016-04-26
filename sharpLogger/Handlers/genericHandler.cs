using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpLogger.Handlers
{
    public abstract class baseHandler
    {
        protected loggerLevels loggerLevel = loggerLevels.NOTSET;
        protected formatter formatter = null;
        protected formatter _defaultFormatter = new formatter();

        public loggerLevels getlevel()
        {
            return this.loggerLevel;
        }

        public void setLevel(loggerLevels level_in)
        {
            this.loggerLevel = level_in;
        }

        public void setFormatter(formatter formatter_in)
        {
            formatter = formatter_in;
        }

        public abstract bool log(logRecord record_in);
        public abstract bool log(string message_in, loggerLevels level_in);

        public abstract void emit(logRecord record);

        public string format(logRecord record)
        {
            formatter fmt = null;
            if(this.formatter != null)
            {
                fmt = this.formatter;
            }
            else
            {
                fmt = _defaultFormatter;
            }

            return fmt.format(record);
        }

        //public bool isEligible(log)
    }
}
