using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using HW11.Exceptions;

namespace HW11.Services.Calculator
{
    public class ExpressionValidator
    {
        public void CheckExpressionCorrect(IEnumerable<Token> expressionInTokens)
        {
            if (!expressionInTokens.Any())
                throw new InvalidSyntaxException("Empty string");

            Token? lastToken = null;
            foreach (var currentToken in expressionInTokens)
            {
                switch (currentToken.Type)
                {
                    case TokenType.Number:
                        break;
                    case TokenType.Bracket:
                        if (lastToken?.Type is TokenType.Operation && currentToken.Value == ")")
                            throw new InvalidSyntaxException("There is only a number before the closing parenthesis " +
                                                             $"{lastToken.Value.Value}{currentToken.Value}");
                        break;
                    case TokenType.Operation:
                        if (lastToken?.Type is TokenType.Operation)
                            throw new InvalidSyntaxException(
                                $"There are two operations in a row: {lastToken.Value.Value} and {currentToken.Value}");
                        else if (lastToken?.Value == "(" && currentToken.Value != "-")
                            throw new InvalidSyntaxException("After opening parenthesis only minus can be " +
                                                             $"{lastToken.Value.Value}{currentToken.Value}");
                        break;
                }

                lastToken = currentToken;
            }
        }
    }
}