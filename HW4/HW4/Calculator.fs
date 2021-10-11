module HW4.Calculator

let calculate (val1: int) operation (val2:int) =
        match operation with
        |"+" -> val1 + val2
        |"-" -> val1 - val2
        |"*" -> val1 * val2
        |":" -> val1 / val2
        |"/" -> val1 / val2