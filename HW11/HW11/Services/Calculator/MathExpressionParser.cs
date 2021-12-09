using System;
using System.Collections.Generic;
using HW11.Exceptions;
using System.Linq;

namespace HW11.Services.Calculator
{
    public class MathExpressionParser
    {
        private readonly char[] _brackets = {'(', ')'};
        private readonly char[] _operations = {'+', '-', '/', '*'};

        public List<Token> ParseToTokens(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return new List<Token>();
            var tokens = new List<Token>();
            var number = "";
            string numberErrorMessage = "There is no such number";
            foreach (var c in expression.Replace(" ", ""))
            {
                if (_brackets.Contains(c))
                {
                    if (!TryAddToken(ref number, tokens, c, TokenType.Bracket))
                        throw new InvalidNumberException(numberErrorMessage + number);
                }
                else if (_operations.Contains(c))
                {
                    if (!TryAddToken(ref number, tokens, c, TokenType.Operation))
                        throw new InvalidNumberException(numberErrorMessage + number);
                }
                else if (char.IsDigit(c) || c == ',' && !number.Contains(','))
                    number += c;
                else
                    throw new InvalidCharacterException($"Unknown character {c}");
            }

            if (!string.IsNullOrEmpty(number))
                if (!double.TryParse(number, out _))
                    throw new ArgumentException(numberErrorMessage + number);
                else
                    tokens.Add(new Token(TokenType.Number, number));
            return tokens;
        }

        private bool TryAddToken(ref string number, ICollection<Token> tokens, char tokenValue, TokenType tokenType)
        {
            if (!string.IsNullOrEmpty(number))
            {
                if (!double.TryParse(number, out _))
                    return false;
                tokens.Add(new Token(TokenType.Number, number));
                number = "";
            }

            tokens.Add(new Token(tokenType, tokenValue.ToString()));
            return true;
        }
    }
}