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
        public void Log_WithConsoleOutputEnabled_LogIsWrittenToConsole()
        {
            // Arrange
            Mock<ILoggerOutput> mockLoggerOutput = new Mock<ILoggerOutput>();
            var loggerSettings = new LoggerSettings();
            loggerSettings.ConsoleOutputEnabled = true;
            var logLevel = Level.Verbose;
            var logger = new Logger(loggerSettings, mockLoggerOutput.Object, It.IsAny<ILoggerOutput>(), It.IsAny<ILoggerOutput>(), logLevel);

            // Act
            logger.Log(logLevel, "");


            // Assert
            mockLoggerOutput.Verify(d => d.LogToOutput(It.IsAny<LogEvent>()));

        }

        [Fact]
        public void Log_WithJsonOutputEnabled_LogIsWrittenToJsonFile()
        {
            // Arrange
            Mock<ILoggerOutput> mockLoggerOutput = new Mock<ILoggerOutput>();
            var loggerSettings = new LoggerSettings();
            loggerSettings.JsonOutputEnabled = true;
            var logLevel = Level.Verbose;
            var logger = new Logger(loggerSettings, It.IsAny<ILoggerOutput>(), mockLoggerOutput.Object, It.IsAny<ILoggerOutput>(), logLevel);

            // Act
            logger.Log(logLevel, "");


            // Assert
            mockLoggerOutput.Verify(d => d.LogToOutput(It.IsAny<LogEvent>()));

        }

        [Fact]
        public void Log_WithXMLOutputEnabled_LogIsWrittenToXMLFile()
        {
            // Arrange
            Mock<ILoggerOutput> mockLoggerOutput = new Mock<ILoggerOutput>();
            var loggerSettings = new LoggerSettings();
            loggerSettings.XMLOutputEnabled = true;
            var logLevel = Level.Verbose;
            var logger = new Logger(loggerSettings, It.IsAny<ILoggerOutput>(), It.IsAny<ILoggerOutput>(), mockLoggerOutput.Object, logLevel);

            // Act
            logger.Log(logLevel, "");


            // Assert
            mockLoggerOutput.Verify(d => d.LogToOutput(It.IsAny<LogEvent>()));

        }
    }
}