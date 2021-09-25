using System;
using CalculatorIL;
using static CalculatorIL.Calculator;

namespace HW2
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var parseResult = InputParser.TryParseArguments(args, out var val1,
                out var operation, out var val2);
            if (parseResult == 0)
            {
                Console.WriteLine($"{val1} {GetDescription(operation)} {val2} = {Calculator.Calculate(val1, operation, val2)}");
                return 0;
            }

            return parseResult;
        }
    }
}