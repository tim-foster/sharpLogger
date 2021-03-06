﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        public string _name = null;
        private List<baseHandler> handlerList = new List<baseHandler>();
        private loggerLevels loggerLevel = loggerLevels.NOTSET;
        private string _message_template = null;

        public int Count { get { return this.handlerList.Count; } }

        public logger(string name_in)
        {
            this._name = name_in;
        }

        public logger(string name_in, string message_template)
        {
            this._name = name_in;
            this._message_template = message_template;
        }

        private logger(string name_in, string message_template, List<baseHandler> handlers) : this(name_in, message_template)
        {
            this.handlerList = handlers;
        }

        public logger ApplyMessageTemplate(string messageTemplate)
        {
            return new logger(this._name, messageTemplate, this.handlerList);
        }

        public bool addHandler(baseHandler handler_in)
        {
            if(this.handlerList == null)
            {
                this.handlerList = new List<baseHandler>();
            }
            this.handlerList.Add(handler_in);
            return true;
        }

        public void removeHandler(baseHandler handler_in)
        {
            throw new NotImplementedException();
        }

        public loggerLevels getlevel()
        {
            return this.loggerLevel;
        }

        public void setLevel(loggerLevels level_in)
        {
            this.loggerLevel = level_in;
        }

        public void critical(string message, object[] args = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            if(isEnabledFor(loggerLevels.CRITICAL))
                executeLog(loggerLevels.CRITICAL, message, args, _func, _pathname, _lineno);
        }

        public void error(string message, object[] args = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            if (isEnabledFor(loggerLevels.ERROR))
                executeLog(loggerLevels.ERROR, message, args, _func, _pathname, _lineno);
        }

        public void warning(string message, object[] args = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            if (isEnabledFor(loggerLevels.WARNING))
                executeLog(loggerLevels.WARNING, message, args, _func, _pathname, _lineno);
        }

        public void info(string message, object[] args = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            if (isEnabledFor(loggerLevels.INFO))
                executeLog(loggerLevels.INFO, message, args, _func, _pathname, _lineno);
        }

        public void debug(string message, object[] args = null, [CallerMemberName] string _func = "", [CallerFilePath] string _pathname = "", [CallerLineNumber] long _lineno = 0)
        {
            if (isEnabledFor(loggerLevels.DEBUG))
                executeLog(loggerLevels.DEBUG, message, args, _func, _pathname, _lineno);
        }
        
        [Obsolete("Should only be used for Debugging/Testing")]
        public void clearHandlers()
        {
            this.handlerList = new List<baseHandler>();
        }
        
        private void callHandler(logRecord record)
        {

        }

        private void executeLog(loggerLevels methodLevel, string message_in, object[] args, string _func, string _pathname, long _lineno)
        {
            if (!string.IsNullOrWhiteSpace(_message_template))
            {
                string conformedMessage_template = _message_template;
                if (conformedMessage_template.Contains("{message}"))
                {
                    conformedMessage_template = conformedMessage_template.Replace("{message}", "{0}");
                }

                if (!conformedMessage_template.Contains("{0}"))
                {
                    conformedMessage_template = $"{conformedMessage_template} {{0}}";
                }

                message_in = string.Format(conformedMessage_template, message_in);
            }
            logRecord record = new logRecord(_name, methodLevel, message_in, args, null, _func, _pathname, _lineno);
            handle(record);
        }

        public void handle(logRecord record_in)
        {

            //TODO: add unit test to check that we properly eat messages when no handler is present
            if (this.handlerList.Count == 0)
            {
                return;
            }
            foreach (baseHandler h in this.handlerList)
            {
                h.log(record_in);
            }
        }

        public bool isEnabledFor(loggerLevels level_in)
        {
            return level_in >= this.getlevel();
        }
    }
}
