module Tests.CalculatorTester
open HW5
open Xunit
open HW5.Operation

[<Theory>]
[<InlineData(10, 20, 30)>]
[<InlineData(25, 30, 55)>]
[<InlineData(-50, -43, -93)>]
[<InlineData(5, -7, -2)>]
let Calculate_Plus_WillReturnCorrectResult val1 val2 expected =
    let result = Calculator.calculate(val1,Operation.Plus,val2)
    Assert.Equal(result, expected, 10)
    
[<Theory>]
[<InlineData(0.23, 0.23, 0)>]
[<InlineData(-5.7, 7, -12.7)>]
[<InlineData(5.333, 7.333, -2)>]
[<InlineData(5.1, 5.11, -0.01)>]
let Calculate_Minus_WillReturnCorrectResult val1 val2 expected = 
    let result = Calculator.calculate(val1,Operation.Minus,val2)
    Assert.Equal(result, expected, 10)
    
[<Theory>]
[<InlineData(5.5, 2, 11)>]
[<InlineData(2.2, 3, 6.6)>]
[<InlineData(-5, -7.1, 35.5)>]
[<InlineData(5.5, -7.2, -39.6)>]
let Calculate_Multiply_WillReturnCorrectResult val1 val2 expected = 
    let result = Calculator.calculate(val1,Operation.Multiply,val2)
    Assert.Equal(result, expected, 10)

[<Theory>]
[<InlineData(55, 2, 27.5)>]
[<InlineData(6.666, 3.333, 2)>]
[<InlineData(-10, -5, 2)>]
[<InlineData(6.666, 2, 3.333)>]
[<InlineData(7, 2, 3.5)>]
let Calculate_Divide_WillReturnCorrectResult val1  val2 expected = 
    let result = Calculator.calculate(val1,Operation.Divide,val2)
    Assert.Equal(result, expected, 10)