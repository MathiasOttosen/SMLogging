using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace SMLogging
{
    public class XMLLoggerOutput : ILoggerOutput
    {
        private const string defaultPath = @"C:\Temp";
        private string path;
        private string xmlFileName;

        public string XMLFileName { get => xmlFileName; private set => xmlFileName = value; }
        public string Path { get => path; set => path = value; }

        public XMLLoggerOutput(string path)
        {
            xmlFileName = DateTime.Now.ToString("yyyyMMdd") + "log.xml"; ;
            this.path = System.IO.Path.Combine(path, xmlFileName);
        }

        public XMLLoggerOutput() : this(defaultPath) { }

        public void LogToOutput(LogEvent logEvent)
        {
            var file = new StreamWriter(XMLFileName, true);
            var xmlConverter = new XmlSerializer(typeof(LogEvent));
            xmlConverter.Serialize(file, logEvent);
            file.Close();
        }

        static void WriteException(XmlWriter writer, string name, Exception exception)
        {
            if (exception == null) return;
            writer.WriteStartElement(name);
            writer.WriteElementString("message", exception.Message);
            writer.WriteElementString("source", exception.Source);
            WriteException(writer, "innerException", exception.InnerException);
            writer.WriteEndElement();
        }
    }
}