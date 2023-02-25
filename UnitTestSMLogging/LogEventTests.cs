using SMLogging;

namespace UnitTestSMLogging
{
    public class LogEventTests
    {
        [InlineData(Level.Verbose)]
        [InlineData(Level.Debug)]
        [InlineData(Level.Information)]
        [InlineData(Level.Warning)]
        [InlineData(Level.Error)]
        [InlineData(Level.Fatal)]
        [Theory]
        public void LogEvent_ConstructWithLevel_ShouldHaveLevel(Level level)
        {
            //Arrange

            //Act
            var logEvent = new LogEvent(level);

            //Assert
            Assert.Equal(level, logEvent.Level);
        }

        [Fact]
        public void LogEvent_ConstructWithMessage_ShouldHaveMessage()
        {
            // Arrange
            const string message = "message";

            // Act
            var logEvent = new LogEvent(message);

            // Assert
            Assert.Equal(message, logEvent.Message);
        }

        [Fact]
        public void LogEvent_ConstructWithException_ShouldHaveException()
        {
            // Arrange 
            Exception exception = new Exception();

            // Act
            var logEvent = new LogEvent(exception);

            // Assert
            Assert.Equal(exception, logEvent.Exception);
        }

       
    }
}