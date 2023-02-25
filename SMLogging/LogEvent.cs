﻿namespace SMLogging
{
    public class LogEvent
    {
        private Level level;
        private string message;
        private Exception? exception;

        public Level Level { get => level; private set => level = value; }

        public string Message { get => message; private set => message = value; }
        public Exception? Exception { get => exception; private set => exception = value; }

        public LogEvent(Level level, string message, Exception? exception)
        {
            this.level = level;
            this.message = message;
            this.exception = exception;
        }

        public LogEvent(Exception? exception) : this(Level.Verbose, string.Empty, exception) { }

        public LogEvent(Level level) : this(level, string.Empty, null) { }

        public LogEvent(string message) : this(Level.Verbose, message, null) { }

        public LogEvent() : this(Level.Verbose, string.Empty, null) { }

        public override string ToString()
        {
            return level.ToString() + message + exception;
        }
    }
}