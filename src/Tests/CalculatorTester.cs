using Xunit;
using static HW1.Calculator.Calculator;

namespace Tests
{
    public class CalculatorTester
    {
        [Theory]
        [InlineData(42, Operation.Plus, 2, 44)]
        [InlineData(23, Operation.Minus, 7, 16)]
        [InlineData(49, Operation.Multiply, 3, 147)]
        [InlineData(42, Operation.Divide, 6, 7)]
        public void CalculateWithValidInputWithoutDivisionByZeroTest(int val1, Operation operation, int val2,
            int expected)
        {
            Assert.Equal(expected, Calculate(val1, operation, val2));
        }
    }
}