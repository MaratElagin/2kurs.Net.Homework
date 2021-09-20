using System.Collections.Generic;
using Xunit;
using static HW1.Calculator.Program;

namespace Tests
{
    public class ProgramTester
    {
        [Theory]
        [MemberData(nameof(WrongTestData))]
        public void IsNotValidArgs(bool isValid, string[] args)
        {
            Assert.False(Main(args) == 0);
        }

        public static IEnumerable<object[]> WrongTestData()
        {
            yield return new object[] {false, new string[] {"1", "5"}};
            yield return new object[] {false, new string[] {"+", "10", "bug"}};
            yield return new object[] {false, new string[] {"3", "/", "0"}};
        }

        [Theory]
        [MemberData(nameof(RightTestData))]
        public void ValidArgs(bool isValid, string[] args)
        {
            Assert.True(Main(args) == 0);
        }

        public static IEnumerable<object[]> RightTestData()
        {
            yield return new object[] {true, new string[] {"1", "+", "10"}};
            yield return new object[] {true, new string[] {"3", "/", "1"}};
            yield return new object[] {true, new string[] {"1", "*", "20"}};
        }
    }
}