module Tests.ProgramTester

open Xunit
open HW4

let validArguments = [|
    [|[|"14"; "+"; "3"|]|]
    [|[|"19"; "-"; "101"|]|]
    [|[|"47"; "*"; "17"|]|]
    [|[|"24"; "/"; "489"|]|]
    [|[|"1134"; ":"; "98541"|]|]  
|]

[<Theory>]
[<MemberData(nameof(validArguments))>]
let ``MainWithValidArgs`` args =
    Assert.True(Program.main(args) = 0)
    
let invalidArguments = [|
    [|[|"1"; "+"; "2"; "="|]|]
    [|[|"131.0"; "-"; "2"|]|]
    [|[|"12"; "*"; "hello"|]|]
    [|[|"144"; "/"; "0"|]|]
    [|[|"131"; ":"; "0"|]|]
|]

[<Theory>]
[<MemberData(nameof(invalidArguments))>]
let ``MainWithInvalidArgs`` args =
    Assert.False(Program.main(args) = 0)
