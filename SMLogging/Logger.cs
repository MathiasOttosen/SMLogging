using Microsoft.Extensions.Options;

namespace SMLogging
{
    public class Logger
    {
        private LoggerSettings settings;
        private string path;
        private List<ILoggerOutput> outputs;
        private Level minimumLevel;

        public List<ILoggerOutput> Outputs { get => outputs; private set => outputs = value; }

        public Logger(LoggerSettings settings, Level minimumLevel, string path)
        {
            this.settings = settings;
            this.minimumLevel = minimumLevel;
            this.path = path;

            var outputSettings = settings.Enabled ?? "";
            outputs = new List<ILoggerOutput>();
            var factory = new LoggerOutputFactory();

            foreach (var outputSetting in outputSettings.Split(",")){
                var newOutput = factory.Create(outputSetting, path);
                if (newOutput != null) {
                    Outputs.Add(newOutput);
                }
            }
        }

        public Logger(LoggerSettings settings) : this(settings, Level.Verbose, "") { }

        public Logger(Level minimumLevel) : this(new LoggerSettings(), minimumLevel, "") { }

        public void Log(Level level, string message, Exception? exception = null)
        {
            // TODO - Apply OCP and make the loggeroutput abstract
            if (IsAboveMinimumLoggingLevel(level))
            {
                var logEvent = new LogEvent(level, message, exception);
                if (Outputs != null)
                {
                    foreach (var output in Outputs)
                    {
                        if (output != null)
                        {
                            output.LogToOutput(logEvent);
                        }
                    }
                }
            }
        }

        public bool IsAboveMinimumLoggingLevel(Level level)
        {
            return level >= minimumLevel;
        }
    }
}