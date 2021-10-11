module Tests.CalculatorTester
open HW4
open Xunit

[<Theory>]
[<InlineData(42, "+", 2, 44)>]
[<InlineData(23, "-", 7, 16)>]
[<InlineData(49, "*", 3, 147)>]
[<InlineData(42, "/", 6, 7)>]
[<InlineData(42, ":", 6, 7)>]
let ``CalculateWithValidInputWithoutDivisionbyZeroTest`` (val1, operation, val2, expectedResult) =
    let actual = Calculator.calculate val1 operation val2
    Assert.Equal(actual, expectedResult)