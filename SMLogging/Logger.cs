namespace SMLogging
{
    public class Logger
    {
        private Level minimumLevel;

        public Logger(Level minimumLevel)
        {
            this.minimumLevel = minimumLevel;
        }

        public void Log(Level level, string message)
        {
            if (level >= minimumLevel)
            {
                // Log to selected out
            }
        }
    }
    public enum Level { Verbose, Debug, Information, Warning, Error, Fatal }
}