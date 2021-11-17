using System.Globalization;
using HW8.Interface;

namespace HW8.Calculator
{
    public class Calculator : ICalculator
    {
        public string Plus(double val1, double val2)
            => (val1 + val2).ToString(CultureInfo.InvariantCulture);

        public string Minus(double val1, double val2)
            => (val1 - val2).ToString(CultureInfo.InvariantCulture);

        public string Multiply(double val1, double val2)
            => (val1 * val2).ToString(CultureInfo.InvariantCulture);

        public string Divide(double val1, double val2) =>
            val2 == 0
                ? "Деление на 0. Результат не определён"
                : (val1 / val2).ToString(CultureInfo.InvariantCulture);
    }
}