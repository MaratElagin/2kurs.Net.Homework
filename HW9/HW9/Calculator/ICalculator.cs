namespace HW9.Calculator
{
    public interface ICalculator
    {
        public CalculationAnswer<string, string> Calculate(string expression);
    }
}