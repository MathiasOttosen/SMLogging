namespace SMLogging
{
    public interface ILoggerOutput
    {
        public void LogToOutput(LogEvent logEvent);
    }
}