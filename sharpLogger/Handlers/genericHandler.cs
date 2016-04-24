using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpLogger.Handlers
{
    public abstract class genericHandler
    {
        protected loggerLevels loggerLevel = loggerLevels.NOTSET;

        public loggerLevels getlevel()
        {
            return this.loggerLevel;
        }

        public void setLevel(loggerLevels level_in)
        {
            this.loggerLevel = level_in;
        }

        public abstract bool log(string message_in, loggerLevels level_in);
    }
}
