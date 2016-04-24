using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace sharpLogger
{
    public class logRecord
    {
        public string args;
        public string asctime;
        public DateTime created;
        public string exc_info;
        public string filename;
        public string funcName;
        public string levelName;
        public int levelNo;
        public int lineno;
        public string module;
        public long msecs;
        public string message;
        public string msg;
        public string name;
        public string pathname;
        public long process;
        public string processName;
        public long relativeCreated;
        public long thread;
        public string threadname;

        public logRecord(string _name, loggerLevels _level, string _msg, string _args, string _exc_info, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            this.name = _name;
            
            this.levelName = _level.ToString();
            this.levelNo = (int)_level;

            this.created = DateTime.Now;
            this.msecs = this.created.Millisecond;

            Process tempProcess = Process.GetCurrentProcess();
            this.processName = tempProcess.ProcessName;
            this.process = tempProcess.Id;
        }

        public string getMessage()
        {
            string msg_out = this.msg;
            if (this.args != null)
            {
                msg_out = String.Format(msg_out, this.args);
            }
            return msg_out;
        }

    }
}
