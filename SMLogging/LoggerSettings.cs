namespace SMLogging
{
    public class LoggerSettings
    {
        public bool ConsoleOutputEnabled { get; set; }

        public LoggerSettings() { }

        public LoggerSettings(bool isConsoleOutputEnabled) {
            ConsoleOutputEnabled = isConsoleOutputEnabled;
        }
    }
}