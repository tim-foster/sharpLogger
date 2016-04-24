using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharpLogger.Handlers
{
    public class flexHandler : genericHandler
    {
        private Action<string> logAction = null;

        public override bool log(string message_in, loggerLevels level_in)
        {
            if (this.getlevel() <= level_in)
            {
                this.logAction(message_in);
                return true;
            }
            return false;
        }
        
        public flexHandler()
        {
            this.logAction = Console.WriteLine;
        }

        public flexHandler( Action<string> logAction_in)
        {
            this.logAction = logAction_in;
        }
    }
}
