using System.Linq.Expressions;

namespace HW11.Services.Calculator
{
    public interface ICalculatorVisitor
    {
        Expression Visit(Expression node);
    }
}