namespace SMLogging
{
    public class Logger
    {
        private Level minimumLevel;
        private ILoggerOutput loggerOutput;

        public Logger(ILoggerOutput loggerOutput, Level minimumLevel)
        {
            this.minimumLevel = minimumLevel;
            this.loggerOutput = loggerOutput;
        }

        public void Log(Level level, string message)
        {
            if (level >= minimumLevel)
            {
                // Log to selected output
                loggerOutput.LogToOutput(level, message);  
            }
        }
    }

    public enum Level { Verbose, Debug, Information, Warning, Error, Fatal }
}