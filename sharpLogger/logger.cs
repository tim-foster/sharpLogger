using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using sharpLogger.Handlers;

namespace sharpLogger
{
    public enum loggerLevels
    {
        CRITICAL=50,
        ERROR=40,
        WARNING=30,
        INFO=20,
        DEBUG=10,
        NOTSET=0
    };

    public class logger
    {
        private List<genericHandler> handlerList = null;
        private loggerLevels loggerLevel = loggerLevels.NOTSET;

        public int Count { get { return this.handlerList.Count; } }


        public bool addHandler(genericHandler handler_in)
        {
            if(this.handlerList == null)
            {
                this.handlerList = new List<genericHandler>();
            }
            this.handlerList.Add(handler_in);
            return true;
        }

        public loggerLevels getlevel()
        {
            return this.loggerLevel;
        }


        public void setLevel(loggerLevels level_in)
        {
            this.loggerLevel = level_in;
        }

        public void critical(string message)
        {
            executeLog(message, loggerLevels.CRITICAL);
        }

        public void error(string message)
        {
            executeLog(message, loggerLevels.ERROR);
        }

        public void warning(string message)
        {
            executeLog(message, loggerLevels.WARNING);
        }

        public void info(string message)
        {
            executeLog(message, loggerLevels.INFO);
        }

        public void debug(string message)
        {
            executeLog(message, loggerLevels.DEBUG);
        }
        
        [Obsolete("Should only be used for Debugging/Testing")]
        public void clearHandlers()
        {
            this.handlerList = new List<genericHandler>();
        }
        

        private void executeLog(string message_in, loggerLevels methodLevel)
        {
            if (this.loggerLevel <= methodLevel)
            {
                foreach (genericHandler h in this.handlerList)
                {
                    h.log(message_in, methodLevel);
                }
            }
        }
    }
}
