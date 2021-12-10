namespace HW8.Interface
{
    public interface ICalculator
    {
        string Plus(double val1, double val2);
        string Minus(double val1, double val2);
        string Multiply(double val1, double val2);
        string Divide(double firstValue, double secondValue);
    }
}