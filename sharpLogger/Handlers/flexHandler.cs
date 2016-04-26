﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharpLogger.Handlers
{
    public class flexHandler : baseHandler
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
        
        public flexHandler()
        {
            this.logAction = Console.WriteLine;
            formatter = _defaultFormatter;
        }

        public flexHandler(Action<string> logAction_in)
        {
            this.logAction = logAction_in;
            formatter = _defaultFormatter;
        }
    }
}
