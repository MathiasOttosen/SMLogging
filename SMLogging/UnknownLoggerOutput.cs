namespace SMLogging
{
    public class UnknownLoggerOutput : ILoggerOutput
    {
        private string unknownSetting;
        public UnknownLoggerOutput(string setting) { 
            unknownSetting = setting;
        }

        public void LogToOutput(LogEvent logEvent)
        {
            Console.WriteLine("Unknown logger type " + unknownSetting);
        }
    }
}