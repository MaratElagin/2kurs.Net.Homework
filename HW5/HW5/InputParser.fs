module HW5.InputParser

open System
open ErrorCode
open MaybeBuilder
open Operation

let checkArgsCount (args: string []) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error ErrorCode.WrongArgumentsCount

let parseOperation (args: string []) : Result<string * Operation * string, ErrorCode> =
    match args.[1] with
    | "+" -> Ok(args.[0], Operation.Plus, args.[2])
    | "-" -> Ok(args.[0], Operation.Minus, args.[2])
    | "*" -> Ok(args.[0], Operation.Multiply, args.[2])
    | "/" -> Ok(args.[0], Operation.Divide, args.[2])
    | ":" -> Ok(args.[0], Operation.Divide, args.[2])
    | _ -> Error ErrorCode.WrongOperation

let parseValues (arg1: string, operation: Operation, arg2: string) =
    try
        Ok(arg1 |> decimal, operation, arg2 |> decimal)
    with
    | _ -> Error ErrorCode.WrongArguments

let checkDivisionByZero (arg1: decimal, operation: Operation, arg2: decimal) =
    match (operation, arg2) with
    | (Operation.Divide, 0m) -> Error ErrorCode.DivideByZero
    | _ -> Ok (arg1, operation, arg2)

let parse (args: string []) =
    maybe {
        let! a = checkArgsCount args
        let! b = parseOperation a
        let! c = parseValues b
        let! d = checkDivisionByZero c
        return d
    }
