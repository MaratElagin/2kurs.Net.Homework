module HW4.Program
open ResultCodes

[<EntryPoint>]
let main argv =
    let mutable val1 = 0
    let mutable operation = ""
    let mutable val2 = 0
    let parseResult = InputParser.tryParseArguments argv &val1 &operation &val2
    if Messages.displayErrorMessage parseResult argv then int parseResult 
    else
        let result = Calculator.calculate val1 operation val2
        printfn $"{val1} {operation} {val2} = {result}"
        0