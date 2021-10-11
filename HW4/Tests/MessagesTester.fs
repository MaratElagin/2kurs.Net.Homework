module Tests.MessagesTester

open HW4
open Xunit
open ResultCodes

[<Fact>]
let ``WrongInput_Return_False``() =
    let args = [|"1";"+";"3"|]
    let actual = Messages.displayErrorMessage ResultCodes.AllCorrect args
    Assert.False(actual)
    
[<Theory>]
[<InlineData(ResultCodes.WrongArgumentsCount, "10", "+", "1", true)>]
[<InlineData(ResultCodes.WrongArguments, "13.0", "-", "s", false)>]
[<InlineData(ResultCodes.WrongOperation, "41", "fd", "1", false)>]
[<InlineData(ResultCodes.DivideByZero, "131", "/", "0", false)>]
[<InlineData(ResultCodes.DivideByZero, "131", ":", "0", false)>]
let ``WrongInput_Return_True`` (code, arg1, arg2, arg3, isFourArgs) =
    if isFourArgs then
        let actual = Messages.displayErrorMessage code [|arg1;arg2;arg3;""|]
        Assert.True(actual)
    else
        let actual = Messages.displayErrorMessage code [|arg1;arg2;arg3|]
        Assert.True(actual);