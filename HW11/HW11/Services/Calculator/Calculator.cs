using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace HW11.Services.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly ExpressionValidator _expValidator = new();
        private readonly MathExpressionParser _parser = new();
        private readonly CalculatorVisitor _calcVisitor = new();

        private readonly Dictionary<string, int> _priorities = new()
        {
            {"(", 0},
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2}
        };

        private readonly Dictionary<string, ExpressionType> _expressionTypes = new()
        {
            {"+", ExpressionType.Add},
            {"-", ExpressionType.Subtract},
            {"*", ExpressionType.Multiply},
            {"/", ExpressionType.Divide}
        };

        public string Calculate(string expression)
        {
            var tokens = _parser.ParseToTokens(expression);
            _expValidator.CheckExpressionCorrect(tokens);
            var convertedExpression = ConvertStringToExpression(tokens);
            var resultExpression = _calcVisitor.VisitDynamic(convertedExpression);
            return resultExpression.ToString(CultureInfo.InvariantCulture);
        }

        private Expression ConvertStringToExpression(IEnumerable<Token> tokens)
        {
            var outputStack = new Stack<Expression>();
            var tokenStack = new Stack<Token>();
            var isNegativeNumber = false;
            Token? lastToken = null;
            foreach (var currentToken in tokens)
            {
                switch (currentToken.Type)
                {
                    case TokenType.Number:
                        outputStack.Push(Expression.Constant(
                            (isNegativeNumber ? -1 : 1) * double.Parse(currentToken.Value),
                            typeof(double)));
                        isNegativeNumber = false;
                        break;
                    case TokenType.Bracket:
                        if (currentToken.Value == "(")
                            tokenStack.Push(currentToken);
                        else CalculateBeforeOpenBracket(outputStack, tokenStack);
                        break;
                    case TokenType.Operation:
                        if (lastToken?.Value == "(")
                            isNegativeNumber = true;
                        else AddOperations(currentToken, outputStack, tokenStack);
                        break;
                }

                lastToken = currentToken;
            }
                               
            CalculateLastOperation(outputStack, tokenStack);
            return outputStack.Pop();
        }

        private void CalculateBeforeOpenBracket(Stack<Expression> outputStack, Stack<Token> tokenStack)
        {
            var operation = tokenStack.Pop();
            while (tokenStack.Count > 0 && operation.Value != "(")
            {
                MakeBinaryExpression(outputStack, operation);
                operation = tokenStack.Pop();
            }
        }
        
        private void CalculateLastOperation(Stack<Expression> outputStack, Stack<Token> tokenStack)
        {
            while (tokenStack.Count > 0)
                MakeBinaryExpression(outputStack, tokenStack.Pop());
        }

        private void AddOperations(Token operation, Stack<Expression> outputStack, Stack<Token> tokenStack)
        {
            while (tokenStack.Count > 0 && _priorities[tokenStack.Peek().Value] >= _priorities[operation.Value])
                MakeBinaryExpression(outputStack, tokenStack.Pop());
            tokenStack.Push(operation);
        }

        private void MakeBinaryExpression(Stack<Expression> outputStack, Token token)
        {
            var rightNode = outputStack.Pop();
            outputStack.Push(Expression.MakeBinary(_expressionTypes[token.Value], outputStack.Pop(), rightNode));
        }
    }
}