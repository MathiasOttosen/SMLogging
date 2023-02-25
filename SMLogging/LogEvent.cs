namespace SMLogging
{
    public class LogEvent
    {
        private Level level;
        private string message;

        public Level Level { get => level; private set => level = value; }

        public string Message { get => message; private set => message = value; }

        public LogEvent(Level level, string message)
        {
            Level = level;
            this.message = message;
        }

        public LogEvent(Level level) : this(level, string.Empty) { }

        public LogEvent(string message) : this(Level.Verbose, message) { }

        public LogEvent() : this(Level.Verbose, string.Empty) { }
    }
}