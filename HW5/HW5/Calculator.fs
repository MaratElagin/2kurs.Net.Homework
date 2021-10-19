module HW5.Calculator
open HW5.Operation

let calculate (val1: decimal, operation, val2) =
        match operation with
        | Operation.Plus -> val1 + val2
        | Operation.Minus -> val1 - val2
        | Operation.Multiply -> val1 * val2
        | Operation.Divide -> val1 / val2