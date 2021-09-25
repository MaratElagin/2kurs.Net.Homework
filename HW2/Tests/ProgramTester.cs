using Xunit;
using static HW2.Program;

namespace Tests
{
    public class ProgramTester
    {
        [Theory]
        [InlineData(false, new [] {"1", "5"})]
        [InlineData(false, new [] {"+", "10", "bug"})]
        [InlineData(false, new [] {"3", "/", "0"})]
        public void IsNotValidArgs(bool isValid, string[] args)
        {
            Assert.False(Main(args) == 0);
        }

        [Theory]
        [InlineData(true, new [] {"1", "+", "10"})]
        [InlineData(true, new [] {"3", "/", "1"})]
        [InlineData(true, new [] {"1", "*", "20"})]
        public void ValidArgs(bool isValid, string[] args)
        {
            Assert.True(Main(args) == 0);
        }
    }
}