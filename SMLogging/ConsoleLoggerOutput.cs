namespace SMLogging
{
    public class ConsoleLoggerOutput : ILoggerOutput
    {
        public ConsoleLoggerOutput()
        {
        }

        public void LogToOutput(LogEvent logEvent)
        {
            Console.WriteLine(logEvent.Level.ToString());
        }
    }
}