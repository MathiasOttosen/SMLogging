using Newtonsoft.Json;

namespace SMLogging
{
    public class JsonLoggerOutput : ILoggerOutput
    {
        private const string defaultPath = @"C:\Temp";
        private string path;
        private string jsonFileName;

        public string JsonFileName { get => jsonFileName; private set => jsonFileName = value; }
        public string Path { get => path; set => path = value; }

        public JsonLoggerOutput(string path)
        {
            jsonFileName = DateTime.Now.ToString("yyyyMMdd") + "log.json"; ;
            this.path = System.IO.Path.Combine(path, jsonFileName);
        }

        public JsonLoggerOutput() : this(defaultPath) { }

        public void LogToOutput(LogEvent logEvent)
        {
            var jsonString = string.Empty;
            if (Exists(Path))
            {
                jsonString = ",";
            }
            jsonString += JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            var file = new StreamWriter(JsonFileName, true);
            file.Write(jsonString);
            file.Close();
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}