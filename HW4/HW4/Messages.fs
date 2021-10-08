module HW4.Messages
open ResultCodes

let displayErrorMessage code (args:string[])=
    if code = ResultCodes.AllCorrect then false
    else match code with
         | ResultCodes.WrongArgumentsCount -> printfn $"The calculator requires 3 arguments, but {args.Length} provided"
         | ResultCodes.WrongArguments -> printfn $"Argument(s) is/are not int: {args.[0]}, {args.[2]}"
         | ResultCodes.WrongOperation -> printfn $"The wrong operation: {args.[1]}  Supported operations: + - * / :"
         | ResultCodes.DivideByZero -> printfn $"{args.[0]} {args.[1]} {args.[2]} division by zero error!"
         true