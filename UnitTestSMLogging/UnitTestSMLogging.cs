using Moq;
using SMLogging;

namespace UnitTestSMLogging
{
    public class UnitTestSMLogging
    {
        [Fact]
        public void Log_AboveMinimumLevel_LogToOutputIsCalled()
        {
            //Arrange
            Mock<ILoggerOutput> mockLoggerOutput = new Mock<ILoggerOutput>();
            var minimumLogLevel = Level.Information;
            var logLevel = Level.Error;
            var logger = new Logger(mockLoggerOutput.Object, minimumLogLevel);
            
            //Act
            logger.Log(logLevel, "");

            //Assert
            mockLoggerOutput.Verify(d => d.LogToOutput(logLevel, ""));
        }

        [Fact]
        public void Log_BelowMinimumLevel_LogToOutputIsNotCalled()
        {
            //Arrange
            Mock<ILoggerOutput> mockLoggerOutput = new Mock<ILoggerOutput>();
            var minimumLogLevel = Level.Error;
            var logLevel = Level.Information;
            var logger = new Logger(mockLoggerOutput.Object, minimumLogLevel);

            //Act
            logger.Log(logLevel, "");

            //Assert
            mockLoggerOutput.VerifyNoOtherCalls();
        }
    }
}