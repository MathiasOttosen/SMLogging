using Moq;
using SMLogging;

namespace UnitTestSMLogging
{
    public class LoggerTests
    {
        [Fact]
        public void Log_AboveMinimumLevel_LogToOutputIsCalled()
        {
            //Arrange
            var minimumLogLevel = Level.Information;
            var logLevel = Level.Error;

            //Act
            var logger = new Logger(minimumLogLevel);

            //Assert
            Assert.True(logger.IsAboveMinimumLoggingLevel(logLevel));
        }

        [Fact]
        public void Log_BelowMinimumLevel_LogToOutputIsNotCalled()
        {
            //Arrange
            var minimumLogLevel = Level.Error;
            var logLevel = Level.Information;

            //Act
            var logger = new Logger(minimumLogLevel);

            //Assert
            Assert.False(logger.IsAboveMinimumLoggingLevel(logLevel));
        }

        [Fact]
        public void Logger_WithConsoleOutputEnabled_ConsoleLoggerOutputIsInstansiated()
        {
            // Arrange
            var loggerSettings = new LoggerSettings();
            loggerSettings.Enabled = "ConsoleLoggerOutput";
            
            // Act
            var logger = new Logger(loggerSettings);

            // Assert
            Assert.Equivalent(logger.Outputs.Count, 1);
            Assert.Equal(typeof(ConsoleLoggerOutput), logger.Outputs.First().GetType());
        }

        [Fact]
        public void Logger_WithJsonOutputEnabled_JsonLoggerOutputIsInstansiated()
        {
            // Arrange
            var loggerSettings = new LoggerSettings();
            loggerSettings.Enabled = "JsonLoggerOutput";

            // Act
            var logger = new Logger(loggerSettings);

            // Assert
            Assert.Equivalent(logger.Outputs.Count, 1);
            Assert.Equal(typeof(JsonLoggerOutput), logger.Outputs.First().GetType());

        }

        [Fact]
        public void Logger_WithXMLOutputEnabled_XMLLoggerOutputIsInstansiated()
        {
            // Arrange
            var loggerSettings = new LoggerSettings();
            loggerSettings.Enabled = "XMLLoggerOutput";

            // Act
            var logger = new Logger(loggerSettings);

            // Assert
            Assert.Equivalent(logger.Outputs.Count, 1);
            Assert.Equal(typeof(XMLLoggerOutput), logger.Outputs.First().GetType());
        }

        [Fact]
        public void Logger_WithMultipleOutputEnabled_MultipleLoggerOutputAreInstansiated()
        {
            // Arrange
            var loggerSettings = new LoggerSettings();
            loggerSettings.Enabled = "ConsoleLoggerOutput,JsonLoggerOutput,XMLLoggerOutput";

            // Act
            var logger = new Logger(loggerSettings);

            // Assert
            Assert.Equivalent(logger.Outputs.Count, 3);
            Assert.True(logger.Outputs.Exists(x => x.GetType() == (typeof(ConsoleLoggerOutput))));
            Assert.True(logger.Outputs.Exists(x => x.GetType() == (typeof(JsonLoggerOutput))));
            Assert.True(logger.Outputs.Exists(x => x.GetType() == (typeof(XMLLoggerOutput))));
        }

        [Fact]
        public void Logger_WithUnknownOutputEnabled_UnknownLoggerOutputAreInstansiated()
        {
            // Arrange
            var loggerSettings = new LoggerSettings();
            loggerSettings.Enabled = "MyLoggerOutput";

            // Act
            var logger = new Logger(loggerSettings);

            // Assert
            Assert.Equivalent(logger.Outputs.Count, 1);
            Assert.True(logger.Outputs.Exists(x => x.GetType() == (typeof(UnknownLoggerOutput))));
        }
    }
}