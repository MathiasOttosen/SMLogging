namespace SMLogging
{
    public class LogEvent
    {
        private Level level;
        private string message;
        private Exception exception;

        public Level Level { get => level; private set => level = value; }

        public string Message { get => message; private set => message = value; }
        public Exception Exception { get => exception; private set => exception = value; }

        public LogEvent(Level level, string message, Exception exception)
        {
            Level = level;
            this.message = message;
            this.Exception = exception;
        }

        public LogEvent(Exception exception) : this(Level.Verbose, string.Empty, exception) { }

        public LogEvent(Level level) : this(level, string.Empty, new Exception()) { }

        public LogEvent(string message) : this(Level.Verbose, message, new Exception()) { }

        public LogEvent() : this(Level.Verbose, string.Empty, new Exception()) { }
    }
}