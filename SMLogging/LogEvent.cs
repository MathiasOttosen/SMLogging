namespace SMLogging
{
    public class LogEvent
    {
        private Level level;

        public LogEvent()
        {
            Level = Level.Information;
        }

        public LogEvent(Level level)
        {
            Level = level;
        }

        public Level Level { get => level; set => level = value; }


    }
}