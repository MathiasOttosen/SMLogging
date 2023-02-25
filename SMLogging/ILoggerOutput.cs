namespace SMLogging
{
    public interface ILoggerOutput
    {

        public void LogToOutput(Level level, string message);
    }
}