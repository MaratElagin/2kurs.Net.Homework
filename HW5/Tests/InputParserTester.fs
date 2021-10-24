module Tests.InputParserTester

open HW5
open Xunit
open ErrorCode
open Operation

let wrongCountArgs =
    [| [| "11"; "+"; "21" |]
       [| "x"; "/"; "10"; "=" |] |]

[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
let checkArgLength i =
    let result =
        InputParser.checkArgsCount wrongCountArgs.[i]
    match result with
    | Ok ok -> Assert.Equal(3, ok.Length)
    | Error error -> Assert.Equal(error, ErrorCode.WrongArgumentsCount)

let argsForParseOperation =
    [| [| "1"; "+"; "2" |]
       [| "1"; "-"; "2" |]
       [| "1"; "/"; "2" |]
       [| "1"; "*"; "2" |]
       [| "1"; "?"; "2" |] |]

[<Theory>]
[<InlineData(0, Operation.Plus)>]
[<InlineData(1, Operation.Minus)>]
[<InlineData(2, Operation.Divide)>]
[<InlineData(3, Operation.Multiply)>]
[<InlineData(4, Operation.Incorrect)>]
let parseOperation i expected =
    let result =
        InputParser.parseOperation argsForParseOperation.[i]

    match result with
    | Ok ok -> Assert.Equal(expected, ok.Item2)
    | Error error -> Assert.Equal(error, ErrorCode.WrongOperation)

let argsForParseValues =
    [| ("11.31", Operation.Plus, "10.19")
       ("rrr", Operation.Plus, "2021") |]

[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
let parseValues i =
    let result =
        InputParser.parseValues argsForParseValues.[i]

    match result with
    | Ok ok ->
        Assert.Equal(11.31m, ok.Item1)
        Assert.Equal(10.19m, ok.Item3)
    | Error error -> Assert.Equal(error, ErrorCode.WrongArguments)
