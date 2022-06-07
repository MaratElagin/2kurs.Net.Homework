using DotNetExam2sem.Dto;

namespace DotNetExam2sem.Services;

public class CreditService
{
    private readonly ConvictionService _convictionService;

    public CreditService(ConvictionService convictionService)
    {
        _convictionService = convictionService;
    }

    public string GetCreditResult(CreditDto creditDto)
    {
        var isConvicted = _convictionService.isConvicted(creditDto.PassportSeries, creditDto.PassportNumber);
        var message = "";
        var result = isConvicted ? 0 : 15;
        if (creditDto.Conviction == "0" && isConvicted)
            message = "Вам отказано в кредите. У вас есть судимость!";

        result += GetScoreByAge(creditDto.Age, creditDto.CreditSum, creditDto.Deposit) +
                  GetScoreByEmployment(creditDto.Employment, creditDto.Age) +
                  GetScoreByPurpose(creditDto.Purpose) + GetScoreByDeposit(creditDto.Deposit, creditDto.CarAge) +
                  GetScoreByOtherCredits(creditDto.OtherCredits, creditDto.Purpose) +
                  GetScoreByCreditSum(creditDto.CreditSum);
        
        return message==""? HandleResult(result) : message;
    }

    private int GetScoreByAge(int age, int creditSum, string deposit) =>
        age switch
        {
            > 20 and 29 => creditSum switch
            {
                < 1000000 => 12,
                > 999999 and < 3000001 => 9,
                _ => 0
            },
            > 28 and < 60 => 14,
            > 59 and < 73 => deposit == "0" ? 0 : 8,
            _ => 0
        };

    private int GetScoreByEmployment(string employment, int age) =>
        employment switch
        {
            "0" => 14,
            "1" => 12,
            "2" => 8,
            "3" => age switch
            {
                < 70 => 5,
                _ => 0
            },
            _ => 0
        };

    private int GetScoreByPurpose(string purpose) =>
        purpose switch
        {
            "0" => 14,
            "1" => 8,
            "2" => 12,
            _ => 0
        };

    private int GetScoreByDeposit(string deposit, int carAge) =>
        deposit switch
        {
            "0" => 14,
            "1" => carAge > 3 ? 3 : 8,
            "2" => 12,
            _ => 0
        };

    private int GetScoreByOtherCredits(string otherCredits, string purpose) =>
        otherCredits switch
        {
            "0" => purpose == "2" ? 0 : 15,
            "1" => 0,
            _ => 0
        };

    private int GetScoreByCreditSum(int creditSum) =>
        creditSum switch
        {
            > -1 and < 1000001 => 12,
            > 1000000 and < 5000001 => 14,
            _ => 8
        };

    private string HandleResult(int result) => 
    result switch
    {
        < 80 => $"Вам отказано в кредите, так как ваш кредитный балл равен {result}",
            >= 80 and < 84 =>
        $"Вы можете получить кредит с процентной ставкой 30%, так как ваш кредитный балл равен {result}",
            >= 84 and < 88 =>
        $"Вы можете получить кредит с процентной ставкой 26%, так как ваш кредитный балл равен {result}",
            >= 88 and < 92 =>
        $"Вы можете получить кредит с процентной ставкой 22%, так как ваш кредитный балл равен {result}",
            >= 92 and < 96 =>
        $"Вы можете получить кредит с процентной ставкой 19%, так как ваш кредитный балл равен {result}",
            >= 96 and < 100 =>
        $"Вы можете получить кредит с процентной ставкой 15%, так как ваш кредитный балл равен {result}",
        100 => $"Вы можете получить кредит с процентной ставкой 12,5%, так как ваш кредитный балл равен {result}",
        _ => $"Кредитный балл > 100"
    };
}