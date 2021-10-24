module HW5.Messages
open HW5.ErrorCode

let getErrorMessage code (args:string[])=
     match code with
         | ErrorCode.WrongArgumentsCount ->  $"The calculator requires 3 arguments, but {args.Length} provided"
         | ErrorCode.WrongArguments ->  $"Argument(s) is/are not int: {args.[0]}, {args.[2]}"
         | ErrorCode.WrongOperation ->  $"The wrong operation: {args.[1]}  Supported operations: + - * / :"
         | ErrorCode.DivideByZero ->  $"{args.[0]} {args.[1]} {args.[2]} division by zero error!"