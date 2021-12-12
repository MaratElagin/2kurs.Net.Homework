namespace HW9.Calculator
{
    public enum TokenType
    {
        Number, 
        Operation,
        Bracket
    }

    public struct Token
    {
        public readonly TokenType Type;
        public readonly string Value;

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}