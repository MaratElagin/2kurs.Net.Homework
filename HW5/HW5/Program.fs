module HW5.Program

open MaybeBuilder
open InputParser
open Calculator
open Messages

[<EntryPoint>]
let main argv =
    let parseResult = maybe{
        let! p = parse argv
        let res = calculate p
        return res
    }
    
    match parseResult with
    | Ok value ->
        printf $"{value}"
        0
    |Error code ->
        printf $"%s{getErrorMessage code argv}"
        int code