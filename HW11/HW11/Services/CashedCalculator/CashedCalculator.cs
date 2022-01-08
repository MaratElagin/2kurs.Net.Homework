﻿using System.Collections.Generic;
using HW11.Services.Calculator;

namespace HW11.Services.CashedCalculator
{
    public class CashedCalculator:ICalculator
    {
        private readonly ICalculator _calculator;
        private static readonly Dictionary<string, string> CashedExpression = new();

        public CashedCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }
        
        public CalculationAnswer<string, string> Calculate(string expression)
        {
            var expressionWithoutSpace = expression?.Replace(" ", "");
            if(expressionWithoutSpace is not null && CashedExpression.ContainsKey(expressionWithoutSpace!))
                return new CalculationAnswer<string, string>(success: CashedExpression[expressionWithoutSpace]);

            var result = _calculator.Calculate(expression);
            if (result.Type == TypeAnswer.Error)
                return result;

            CashedExpression[expressionWithoutSpace] = result.Success;
            return result;
        }
    }
}