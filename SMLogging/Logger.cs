using Microsoft.Extensions.Options;

namespace SMLogging
{
    public class Logger
    {
        private LoggerSettings settings;
        private ILoggerOutput consoleLoggerOutput;
        private ILoggerOutput xmlLoggerOutput;
        private ILoggerOutput jsonLoggerOutput;
        private Level minimumLevel;

        public Logger(LoggerSettings settings, ILoggerOutput consoleLoggerOutput, ILoggerOutput jsonLoggerOutput, ILoggerOutput xmlLoggerOutput, Level minimumLevel)
        {
            this.settings = settings;
            this.minimumLevel = minimumLevel;
            this.consoleLoggerOutput = consoleLoggerOutput;
            this.jsonLoggerOutput = jsonLoggerOutput;
            this.xmlLoggerOutput = xmlLoggerOutput;
        }

        public Logger(LoggerSettings settings, Level minimumLevel) : this(settings, new ConsoleLoggerOutput(), new JsonLoggerOutput(), new XMLLoggerOutput(), minimumLevel) { }

        public Logger(ILoggerOutput loggerOutput, Level minimumLevel) : this(new LoggerSettings(), loggerOutput, new JsonLoggerOutput(), new XMLLoggerOutput(), minimumLevel) { }

        public Logger(LoggerSettings settings) : this(settings, new ConsoleLoggerOutput(), new JsonLoggerOutput(), new XMLLoggerOutput(), Level.Verbose) { }

        public Logger(Level minimumLevel) : this(new LoggerSettings(), new ConsoleLoggerOutput(), new JsonLoggerOutput(), new XMLLoggerOutput(), minimumLevel) { }

        public void Log(Level level, string message, Exception? exception = null)
        {
            if (IsAboveMinimumLoggingLevel(level))
            {
                var logEvent = new LogEvent(level, message, exception);

                if (settings.ConsoleOutputEnabled)
                {
                    consoleLoggerOutput.LogToOutput(logEvent);
                }
                if (settings.JsonOutputEnabled)
                {
                    jsonLoggerOutput.LogToOutput(logEvent);

                }
                if (settings.XMLOutputEnabled)
                {
                    xmlLoggerOutput.LogToOutput(logEvent);
                }
            }
        }

        public bool IsAboveMinimumLoggingLevel(Level level)
        {
            return level >= minimumLevel;
        }
    }
}