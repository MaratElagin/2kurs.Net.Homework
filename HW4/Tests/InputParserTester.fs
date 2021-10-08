module Tests.InputParserTester

open HW4
open Xunit
open ResultCodes

let check(args:string[]) (expectedCode:ResultCodes)=
    let mutable val1 = 0
    let mutable operation = ""
    let mutable val2 = 0
    let actualCode = InputParser.tryParseArguments args &val1 &operation &val2
    Assert.Equal(expectedCode, actualCode)

[<Fact>]
let ``WrongArgumentsCount``() =
    let args = [|"1"; "+"; "123"; "="|]
    check args ResultCodes.WrongArgumentsCount
    
let wrongArguments = [|
    [|[|"x"; "/"; "10"|]|]
    [|[|"5"; "*"; "x"|]|]
    [|[|"Hello"; "+"; "World"|]|]
    [|[|"Hello"; "-"; "156"|]|]
|]
[<Theory>]
[<MemberData(nameof(wrongArguments))>]
let ``TryParseArguments_WrongArguments``args =
    check args ResultCodes.WrongArguments

[<Fact>]
let ``TryParseArguments_WrongOperation``=
    let args = [|"10"; "?"; "12"|]
    check args ResultCodes.WrongOperation

let divideByZeroArguments = [|
    [|[|"144"; "/"; "0"|]|]
    [|[|"131"; ":"; "0"|]|]
|]

[<Theory>]
[<MemberData(nameof(divideByZeroArguments))>]
let ``TryParseArguments_DivideByZero``args =
    check args ResultCodes.DivideByZero
    
let correctArguments = [|
    [|[|"1"; "+"; "12"|]|]
    [|[|"13"; "-"; "56"|]|]
    [|[|"144"; "*"; "170"|]|]
    [|[|"7"; "/"; "41"|]|]
    [|[|"81"; ":"; "23"|]|]
|]

[<Theory>]
[<MemberData(nameof(correctArguments))>]
let ``TryParseArguments_AllCorrect`` args =
    check args ResultCodes.AllCorrect