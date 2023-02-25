namespace SMLogging
{
    public class ConsoleLoggerOutput : ILoggerOutput
    {
        public ConsoleLoggerOutput()
        {
        }

        public void LogToOutput(Level level, string message)
        {
            Console.WriteLine(level.ToString(), message);
        }
    }
}