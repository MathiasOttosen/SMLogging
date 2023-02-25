using SMLogging;

namespace UnitTestSMLogging
{
    public class ConsoleLoggerOutputTests
    {
        [Fact]
        public void LogToOutput_Called_ShouldWriteToConsole()
        {
            // Arrange
            var loggerOutput = new ConsoleLoggerOutput();
            var logEvent = new LogEvent();
            var expected = logEvent.ToString();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            loggerOutput.LogToOutput(logEvent);

            // Assert
            var output = stringWriter.ToString().Split(Environment.NewLine);
            Assert.Equal(logEvent.ToString(), output[0]);

        }
    }
}