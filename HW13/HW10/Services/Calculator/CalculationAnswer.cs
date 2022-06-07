namespace HW10.Services.Calculator
{
    public enum TypeAnswer
    {
        Success,
        Error
    }
    
    public class CalculationAnswer<TSuccess, TError>
    {
        public readonly TypeAnswer Type;
        public readonly TSuccess Success;
        public readonly TError Error;

        public CalculationAnswer(TSuccess success)
        {
            Type = TypeAnswer.Success;
            Success = success;
        }
        
        public CalculationAnswer(TError error)
        {
            Type = TypeAnswer.Error;
            Error = error;
        }
    }
}