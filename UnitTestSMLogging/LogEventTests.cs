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
            var logEvent = new LogEvent(level);

            //Act

            //Assert
            Assert.Equal(level, logEvent.Level);
        }
    }
}