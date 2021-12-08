using System.Linq;
using HW10.Services.Calculator;
using HW10.Services.Database;
using HW10.Services.Database.Models;

namespace HW10.Services.CashedCalculator
{
    public class CashedCalculator:ICalculator
    {
        private readonly ICalculator _calculator;
        private readonly ApplicationContext _cashedExpression;

        public CashedCalculator(ICalculator calculator, ApplicationContext cashedExpression)
        {
            _calculator = calculator;
            _cashedExpression = cashedExpression;
        }

        public CalculationAnswer<string, string> Calculate(string expression)
        {
            var expressionWithoutSpace = expression?.Replace(" ", "");
            var possibleResult = _cashedExpression.CalculatingExpressions
                .FirstOrDefault(exp => exp.Expression == expressionWithoutSpace)?.Result;
            if (possibleResult is not null)
                return new CalculationAnswer<string, string>(success: possibleResult);

            var result = _calculator.Calculate(expression);
            if (result.Type == TypeAnswer.Error)
                return result;

            var calculatingExpression = new CalculatingExpression
            {
                Expression = expressionWithoutSpace,
                Result = result.Success
            };
            _cashedExpression.Add(calculatingExpression);
            _cashedExpression.SaveChanges();
            return result;
        }
    }
}