using Newtonsoft.Json;
using SMLogging;
using System.Text;
using System.Xml.Serialization;

namespace UnitTestSMLogging
{
    public class XMLLoggerOutputTests
    {
        [Fact]
        public void LogToOutput_Called_ShouldWriteXMLToFile()
        {
            // Arrange 
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var xmlLoggerOutput = new XMLLoggerOutput(path);
            File.Delete(xmlLoggerOutput.Path);
            var logEvent = new LogEvent(Level.Information, "1", new Exception("ex1"));
            var stringWriter = new Utf8StringWriter();
            var xmlConverter = new XmlSerializer(typeof(LogEvent));
            xmlConverter.Serialize(stringWriter, logEvent);
            var expectedContent = stringWriter.ToString();
            stringWriter.Close();

            // Act
            xmlLoggerOutput.LogToOutput(logEvent);

            // Assert
            var file = new StreamReader(xmlLoggerOutput.Path);

            var actualContent = file.ReadToEnd();
            file.Close();
            Assert.Equal(expectedContent, actualContent);
            File.Delete(xmlLoggerOutput.Path);
        }

        [Fact]
        public void LogToOutput_CalledTwice_ShouldAppendXMLToFile()
        {
            // Arrange 
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var xmlLoggerOutput = new XMLLoggerOutput(path);
            File.Delete(xmlLoggerOutput.Path);
            var logEvent = new LogEvent(Level.Information, "1", new Exception("ex1"));
            var logEvent2 = new LogEvent(Level.Error, "2", new Exception("ex2"));
            var stringWriter = new Utf8StringWriter();
            var xmlConverter = new XmlSerializer(typeof(LogEvent));
            xmlConverter.Serialize(stringWriter, logEvent);
            xmlConverter.Serialize(stringWriter, logEvent2);
            var expectedContent = stringWriter.ToString();
            stringWriter.Close();

            // Act
            xmlLoggerOutput.LogToOutput(logEvent);
            xmlLoggerOutput.LogToOutput(logEvent2);

            // Assert
            var file = new StreamReader(xmlLoggerOutput.Path);

            var actualContent = file.ReadToEnd();
            file.Close();
            Assert.Equal(expectedContent, actualContent);
            File.Delete(xmlLoggerOutput.Path);
        }

        [Fact]
        public void XMLFilename_Get_ContainsTodaysDate()
        {
            // Arrange
            var xmlLoggerOutput = new XMLLoggerOutput();
            var todaysDate = DateTime.Now.ToString("yyyyMMdd");

            // Act

            // Assert
            Assert.Contains(todaysDate, xmlLoggerOutput.XMLFileName);
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return new UTF8Encoding(false); }
        }
    }
}