module HW4.InputParser

open System
open ResultCodes

let supportedOperations = [| "+"; "-"; "*"; "/"; ":" |]
let checkArgsCount (args: string []) = args.Length = 3

let tryParseArguments (args: string []) (val1: outref<int>) (operation: outref<string>) (val2: outref<int>) =
    operation <- args.[1]
    if not (checkArgsCount args) then
        ResultCodes.WrongArgumentsCount
    elif not (Int32.TryParse(args.[0], &val1) && Int32.TryParse(args.[2], &val2)) then
        ResultCodes.WrongArguments
    elif not (Array.contains operation supportedOperations) then
        ResultCodes.WrongOperation
    elif (val2 = 0 && (operation = ":" || operation = "/")) then ResultCodes.DivideByZero
    else
        ResultCodes.AllCorrect
