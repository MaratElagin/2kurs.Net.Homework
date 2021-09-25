using System.Collections.Generic;
using Xunit;
using static HW1.Calculator.Program;

namespace Tests
{
    public class ProgramTester
    {
        [Theory]
        [InlineData(false, new string[] {"+", "10", "bug"})]
        [InlineData(false, new string[] {"3", "/", "0"})]
        [InlineData(false, new string[] {"1", "5"})]
        public void IsNotValidArgs(bool isValid, string[] args)
        {
            Assert.False(Main(args) == 0);
        }

        [Theory]
        [InlineData(true, new string[] {"1", "+", "10"})]
        [InlineData(true, new string[] {"3", "/", "1"})]
        [InlineData(true, new string[] {"1", "*", "20"})]
        public void ValidArgs(bool isValid, string[] args)
        {
            Assert.True(Main(args) == 0);
        }
    }
}