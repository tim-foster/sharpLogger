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
        public Dictionary<string, object> attributes = null;

        private object[] _args;
        public object[] args
        {
            get
            {
                return _args;
            }
            set
            {
                _args = value;
                attributeSet("args", value);
            }
        }

        private string _asctime;
        public string asctime
        {
            get
            {
                return _asctime;
            }
            set
            {
                _asctime = value;
                attributeSet("asctime", value);
            }
        }

        private DateTime _created;
        public DateTime created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
                attributeSet("created", value);
            }
        }

        private string _exc_info;
        public string exc_info
        {
            get
            {
                return _exc_info;
            }
            set
            {
                _exc_info = value;
                attributeSet("exc_info", value);
            }
        }

        private string _filename;
        public string filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                attributeSet("filename", value);
            }
        }

        private string _funcName;
        public string funcName
        {
            get
            {
                return _funcName;
            }
            set
            {
                _funcName = value;
                attributeSet("funcName", value);
            }
        }

        private string _levelName;
        public string levelName
        {
            get
            {
                return _levelName;
            }
            set
            {
                _levelName = value;
                attributeSet("levelName", value);
            }
        }

        private int _levelNo;
        public int levelNo
        {
            get
            {
                return _levelNo;
            }
            set
            {
                _levelNo = value;
                attributeSet("levelNo", value);
            }
        }

        private loggerLevels _levelEnum;
        public loggerLevels levelEnum
        {
            get
            {
                return _levelEnum;
            }
            set
            {
                _levelEnum = value;
                attributeSet("levelEnum", value);
            }
        }

        private long _lineno;
        public long lineno
        {
            get
            {
                return _lineno;
            }
            set
            {
                _lineno = value;
                attributeSet("lineno", value);
            }
        }

        private string _module;
        public string module
        {
            get
            {
                return _module;
            }
            set
            {
                _module = value;
                attributeSet("module", value);
            }
        }

        private long _msecs;
        public long msecs
        {
            get
            {
                return _msecs;
            }
            set
            {
                _msecs = value;
                attributeSet("msecs", value);
            }
        }

        private string _message;
        public string message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                attributeSet("message", value);
            }
        }

        private string _msg;
        public string msg
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
                attributeSet("msg", value);
            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                attributeSet("name", value);
            }
        }

        private string _pathname;
        public string pathname
        {
            get
            {
                return _pathname;
            }
            set
            {
                _pathname = value;
                attributeSet("pathname", value);
            }
        }

        private long _process;
        public long process
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
                attributeSet("process", value);
            }
        }

        private string _processName;
        public string processName
        {
            get
            {
                return _processName;
            }
            set
            {
                _processName = value;
                attributeSet("processName", value);
            }
        }

        private long _relativeCreated;
        public long relativeCreated
        {
            get
            {
                return _relativeCreated;
            }
            set
            {
                _relativeCreated = value;
                attributeSet("relativeCreated", value);
            }
        }

        private long _thread;
        public long thread
        {
            get
            {
                return _thread;
            }
            set
            {
                _thread = value;
                attributeSet("thread", value);
            }
        }

        private string _threadname;
        public string threadname
        {
            get
            {
                return _threadname;
            }
            set
            {
                _threadname = value;
                attributeSet("threadname", value);
            }
        }

        public logRecord(string _name, loggerLevels _level, string _msg, object[] _args, string _exc_info = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            attributes = new Dictionary<string, object>();
            name = _name;
            
            levelName = _level.ToString();
            levelNo = (int)_level;
            levelEnum = _level;

            created = DateTime.Now;
            msecs = created.Millisecond;

            Process tempProcess = Process.GetCurrentProcess();
            processName = tempProcess.ProcessName;
            process = tempProcess.Id;

            this._msg = _msg;

            args = _args;

            funcName = _func;
            pathname = _pathname;
            lineno = _lineno;
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

        private void attributeSet(string attribute, object value_in)
        {
            if (attributes != null)
            {
                attributes[attribute] = value_in;
            }
            else
            {
                attributes = new Dictionary<string, object>();
                attributes[attribute] = value_in;
            }
        }

    }
}
