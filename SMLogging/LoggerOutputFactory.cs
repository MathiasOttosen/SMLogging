namespace SMLogging
{
    public class LoggerOutputFactory
    {
        public ILoggerOutput Create(string setting, string path)
        {
            try
            {
                return Activator.CreateInstance(
                    Type.GetType(typeName: $"SMLogging.{setting}"),
                        args: new object[] { path }) as ILoggerOutput;
            }
            catch
            {
                return new UnknownLoggerOutput(setting);
            }
        }
    }
}