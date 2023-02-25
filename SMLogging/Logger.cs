using Microsoft.Extensions.Options;

namespace SMLogging
{
    public class Logger
    {
        private LoggerSettings settings;
        private ILoggerOutput consoleLoggerOutput;
        private Level minimumLevel;

        public Logger(LoggerSettings settings, ILoggerOutput loggerOutput, Level minimumLevel)
        {
            this.settings = settings;
            this.minimumLevel = minimumLevel;
            consoleLoggerOutput = loggerOutput;
        }

        public Logger(LoggerSettings settings, Level minimumLevel) : this(settings, new ConsoleLoggerOutput(), minimumLevel) { }

        public Logger(ILoggerOutput loggerOutput, Level minimumLevel) : this(new LoggerSettings(), loggerOutput, minimumLevel) { }

        public Logger(LoggerSettings settings) : this(settings, new ConsoleLoggerOutput(), Level.Verbose) { }

        public Logger(Level minimumLevel) : this(new LoggerSettings(), new ConsoleLoggerOutput(), minimumLevel) { }

        public void Log(Level level, string message, Exception? exception = null)
        {
            if (IsAboveMinimumLoggingLevel(level))
            {
                var logEvent = new LogEvent(level, message, exception);

                if (settings.ConsoleOutputEnabled)
                {
                    consoleLoggerOutput.LogToOutput(logEvent);
                }
            }
        }

        public bool IsAboveMinimumLoggingLevel(Level level)
        {
            return level >= minimumLevel;
        }
    }
}