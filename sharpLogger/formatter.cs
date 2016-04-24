using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpLogger
{
    class formatter
    {
        string formatString;
        string dateFormat;

        public formatter(string _format, string _dateFmt)
        {
            this.formatString = _format;
            this.dateFormat = _dateFmt;
        }

        public string format(logRecord record_in)
        {
            return "";
        }
        
        public string formatTime(logRecord record_in, string dateFormat = null)
        {
            return "";
        }
    }
}
