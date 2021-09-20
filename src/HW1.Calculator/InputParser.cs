using System;
using System.Linq;
using static HW1.Calculator.Calculator;

namespace HW1.Calculator
{
    public class InputParser
    {
        public const int AllCorrect = 0;
        public const int WrongArgs = 1;
        public const int WrongOperation = 2;
        public const int WrongArgsCount = 3;
        public const int DivideByZero = 4;
        private static readonly string[] SupportedOperations = {"+", "-", "*", "/"};

        public static int TryParseArguments(string[] args, out int val1, out Operation operation, out int val2)
        {
            val1 = default;
            operation = default;
            val2 = default;

            if (!CheckArgsCount(args)) return WrongArgsCount;
            if (!TryParseOperation(args[1], out operation)) return WrongOperation;
            if (!TryParseValue(args[0], out val1) || !TryParseValue(args[2], out val2))
                return WrongArgs;
            if (operation == Operation.Divide && val2 == 0)
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} division by zero error!");
                return DivideByZero;
            }

            return AllCorrect;
        }

        private static bool CheckArgsCount(string[] args)
        {
            if (args.Length == 3)
                return true;
            Console.WriteLine($"The calculator requires 3 arguments, but {args.Length} provided");
            return false;
        }

        private static bool TryParseOperation(string op, out Operation operation)
        {
            var numberOperation = op switch
            {
                "+" => 0,
                "-" => 1,
                "*" => 2,
                "/" => 3,
                _ => 4
            };
            if (numberOperation > 3)
            {
                Console.WriteLine($"Unsupported operation received: {op}"
                                  + $" Supported operations are {SupportedOperations.Aggregate((c, n) => $"{c} {n}")}");
                operation = default;
                return false;
            }

            operation = (Operation) numberOperation;
            return true;
        }

        private static bool TryParseValue(string arg, out int val)
        {
            var isVal = int.TryParse(arg, out val);
            if (!isVal) Console.WriteLine($"Value is not int: {arg}");
            return isVal;
        }
    }
}