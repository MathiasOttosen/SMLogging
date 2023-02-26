namespace SMLogging
{
    public class ConsoleLoggerOutput : ILoggerOutput
    {
        public ConsoleLoggerOutput(string path)
        {

        }

        public ConsoleLoggerOutput()
        {
        }

        public void LogToOutput(LogEvent logEvent)
        {
            Console.WriteLine(logEvent.ToString());
        }
    }
}