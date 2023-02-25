using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using SMLogging;

namespace UnitTestSMLogging
{
    public class JsonLoggerOutputTests
    {
        [Fact]
        public void LogToOutput_Called_ShouldWriteJsonToFile()
        {
            // Arrange
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var jsonLoggerOutput = new JsonLoggerOutput(path);
            File.Delete(jsonLoggerOutput.Path);
            var logEvent = new LogEvent(Level.Information, "1", new Exception("ex1"));
            var expectedContent = JsonConvert.SerializeObject(logEvent, Formatting.Indented);

            // Act
            jsonLoggerOutput.LogToOutput(logEvent);

            // Assert
            var file = new StreamReader(jsonLoggerOutput.Path);

            var actualContent = file.ReadToEnd();
            file.Close();
            Assert.Equal(expectedContent, actualContent);
            File.Delete(jsonLoggerOutput.Path);
        }

        [Fact]
        public void LogToOutput_CalledTwice_ShouldAppendJsonToFile()
        {
            // Arrange
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var jsonLoggerOutput = new JsonLoggerOutput(path);
            File.Delete(jsonLoggerOutput.Path);
            var logEvent = new LogEvent(Level.Information, "1", new Exception("ex1"));
            var logEvent2 = new LogEvent(Level.Error, "2", new Exception("ex2"));
            var expectedContent = JsonConvert.SerializeObject(logEvent, Formatting.Indented) + "," +
                JsonConvert.SerializeObject(logEvent2, Formatting.Indented);

            // Act
            jsonLoggerOutput.LogToOutput(logEvent);
            jsonLoggerOutput.LogToOutput(logEvent2);

            // Assert
            var file = new StreamReader(jsonLoggerOutput.Path);
            var actualContent = file.ReadToEnd();
            file.Close();
            Assert.Equal(expectedContent, actualContent);
            File.Delete(jsonLoggerOutput.Path);
        }

        [Fact]
        public void JsonFilename_Get_ContainsTodaysDate()
        {
            // Arrange
            var jsonLoggerOutput = new JsonLoggerOutput();
            var todaysDate = DateTime.Now.ToString("yyyyMMdd");

            // Act

            // Assert
            Assert.Contains(todaysDate, jsonLoggerOutput.JsonFileName);

        }
    }
}