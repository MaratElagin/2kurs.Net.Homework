using Xunit;
using static HW1.Calculator.InputParser;
using static HW1.Calculator.Calculator;

namespace Tests
{
    public class InputParserTester
    {
        private void Check(string[] args, int expectedCode)
        {
            var actualCode = TryParseArguments(args, out _, out _, out _);
            Assert.Equal(expectedCode, actualCode);
        }

        private void Check(string[] args, int expectedCode, int expVal1, Operation expOperation, int expVal2)
        {
            var actualCode = TryParseArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expectedCode, actualCode);
            Assert.Equal(expVal1, val1);
            Assert.Equal(expOperation, operation);
            Assert.Equal(expVal2, val2);
        }

        [Fact]
        public void ArgsCountIsNotValid()
        {
            Check(new[] {"100", "/", "2", "10"}, WrongArgsCount);
        }

        [Fact]
        public void AreNotValidArgs()
        {
            Check(new[] {"x", "/", "2"}, WrongArgs);
            Check(new[] {"5", "*", "c"}, WrongArgs);
        }

        [Fact]
        public void IsNotValidOperationTest()
        {
            Check(new[] {"10", "x", "20"}, WrongOperation);
        }

        [Fact]
        public void DivisionByZeroError()
        {
            Check(new[] {"5", "/", "0"}, DivideByZero);
        }

        [Fact]
        public void AllIsCorrect()
        {
            Check(new[] {"5", "+", "7"}, 0, 5, Operation.Plus, 7);
            Check(new[] {"34", "-", "9"}, 0, 34, Operation.Minus, 9);
            Check(new[] {"44", "*", "39"}, 0, 44, Operation.Multiply, 39);
            Check(new[] {"54", "/", "71"}, 0, 54, Operation.Divide, 71);
        }
    }
}