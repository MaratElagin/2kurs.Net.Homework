using System;
using System.ComponentModel;
using System.Reflection;

namespace HW1.Calculator
{
    public class Calculator
    {
        public enum Operation
        {
            [Description("+")]
            Plus,
            [Description("-")]
            Minus,
            [Description("*")]
            Multiply,
            [Description("/")]
            Divide,
            IncorrectOperation
        };

        public static string GetDescription(Enum operation)
        {
            Type type = operation.GetType();

            MemberInfo[] memInfo = type.GetMember(operation.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute) attrs[0]).Description;
            }

            return operation.ToString();
        }
        public static double Calculate(int val1, Operation operation, int val2)
        {
            return operation switch
            {
                Operation.Plus => val1 + val2,
                Operation.Minus => val1 - val2,
                Operation.Multiply => val1 * val2,
                Operation.Divide => val1 / val2
            };
        }
    }
}