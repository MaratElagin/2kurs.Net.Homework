namespace DotNetExam2sem.Services;

public class ConvictionService
{
    private HashSet<string> convictedPassportsHashSet = new HashSet<string>(new string[]{
        "1111 111111",
        "1234 567890",
        "5327 501637",
        "5482 053040",
        "3016 511504",
    });

    public  bool isConvicted(string passportSeries, string passportNumber)=>
        convictedPassportsHashSet.Contains($"{passportSeries} {passportNumber}");
}