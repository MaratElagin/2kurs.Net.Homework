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
            operation = op switch
            {
                "+" => Operation.Plus,
                "-" => Operation.Minus,
                "*" => Operation.Multiply,
                "/" => Operation.Divide,
                _ => Operation.IncorrectOperation
            };
            var isOperation = operation is not Operation.IncorrectOperation;
            if (!isOperation)
                Console.WriteLine($"Unsupported operation received: {op}");
            return isOperation;
        }

        private static bool TryParseValue(string arg, out int val)
        {
            var isVal = int.TryParse(arg, out val);
            if (!isVal) Console.WriteLine($"Value is not int: {arg}");
            return isVal;
        }
    }
}