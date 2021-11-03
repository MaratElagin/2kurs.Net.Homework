module HW6.Calculator
open HW6.Expression
open HW6.Operation;
let tryCalculate expression =
        match expression.Operation with
        |Operation.Plus -> Ok (expression.V1 + expression.V2)
        |Operation.Minus -> Ok (expression.V1 - expression.V2)
        |Operation.Multiply-> Ok (expression.V1 * expression.V2)
        |Operation.Divide -> match expression.V2 with
                        | 0m -> Error "Division by zero"
                        | _ -> Ok (expression.V1 / expression.V2)


