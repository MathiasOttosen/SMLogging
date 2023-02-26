using SMLogging;

internal class Program
{
    private static void Main(string[] args)
    {
        var settings = new LoggerSettings();
        settings.Enabled = "ConsoleLoggerOutput,XMLLoggerOutput,JsonLoggerOutput";
        
        // path to program D:\dev\SMLogging\project\bin\Debug\net6.0
        var path = AppDomain.CurrentDomain.BaseDirectory;

        var logger = new Logger(settings, Level.Error, path);

        logger.Log(Level.Error, "Hello Logger!", new Exception());

        Console.WriteLine("Hello, World!");
    }
}