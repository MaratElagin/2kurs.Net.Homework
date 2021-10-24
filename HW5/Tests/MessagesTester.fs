module Tests.MessagesTester

open HW5
open Xunit
open ErrorCode

[<Theory>]
[<InlineData(ErrorCode.WrongArgumentsCount, "10", "+", "1", true)>]
[<InlineData(ErrorCode.WrongArguments, "13.0", "-", "s", false)>]
[<InlineData(ErrorCode.WrongOperation, "41", "fd", "1", false)>]
[<InlineData(ErrorCode.DivideByZero, "131", "/", "0", false)>]
[<InlineData(ErrorCode.DivideByZero, "131", ":", "0", false)>]
let ``WrongInput_Return_True`` (code, arg1, arg2, arg3, isFourArgs) =
    if isFourArgs then
        let actual =
            Messages.getErrorMessage code [| arg1; arg2; arg3; "" |]

        Assert.True(actual.Length <> 0)
    else
        let actual =
            Messages.getErrorMessage code [| arg1; arg2; arg3 |]

        Assert.True(actual.Length <> 0)
