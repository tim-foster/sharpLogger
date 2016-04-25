using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace sharpLogger
{
    
    public class formatter
    {
        const string BASIC_MSG_FORMAT = "{levelname}:{name}:{message}";
        const string DEFAULT_MSG_FORMAT = "{message}";
        const string DEFAULT_TIME_FORMAT = "%Y-%m-%d %H:%M:%S";
        const string REGEX_PATTERN = @"(?<=\{)[^}]*(?=\})";

        public List<string> formatList = new List<string>();

        public string formatString;
        public string dateFormat;

        public formatter(string _format=DEFAULT_MSG_FORMAT, string _dateFmt=DEFAULT_TIME_FORMAT)
        {
            this.formatString = parseFormatString(_format);
            this.dateFormat = _dateFmt;

        }

        public string format(logRecord record_in)
        {
            StringBuilder b = new StringBuilder();
            record_in.message = record_in.getMessage();

            object[] formatArgs = getStringFormatObjects(record_in);      
            return String.Format(formatString, formatArgs);
        }
        
        public string formatTime(logRecord record_in, string dateFormat = null)
        {
            return "";
        }

        private string parseFormatString(string format_in)
        {
            MatchCollection matches = Regex.Matches(format_in, REGEX_PATTERN);
            int counter = 0;
            string tempFormatString = format_in;
            foreach(Match match in matches)
            {
                tempFormatString = tempFormatString.Replace(match.ToString(), String.Format("{0}", counter++));
                formatList.Add(match.ToString());
            }
            return tempFormatString;
        }

        private object[] getStringFormatObjects(logRecord record_in)
        {
            List<object> tempObjArray = new List<object>();
            foreach(string attr in formatList)
            {
                tempObjArray.Add(record_in.attributes[attr]);
            }
            return tempObjArray.ToArray();
        }
    }
}
