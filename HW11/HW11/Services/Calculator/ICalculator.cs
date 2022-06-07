namespace HW11.Services.Calculator
{
    public interface ICalculator
    {
        public CalculationAnswer<string, string> Calculate(string expression);
    }
}