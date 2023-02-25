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
            var isConsoleOutputEnabled = true;
            var loggerSettings = new LoggerSettings(isConsoleOutputEnabled);
            var logLevel = Level.Verbose;
            var logger = new Logger(loggerSettings, mockLoggerOutput.Object, logLevel);

            // Act
            logger.Log(logLevel, "");


            // Assert
            mockLoggerOutput.Verify(d => d.LogToOutput(It.IsAny<LogEvent>()));

        }
    }
}