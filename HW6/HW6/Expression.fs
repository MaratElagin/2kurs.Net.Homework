module HW6.Expression
open HW6.Operation;

[<CLIMutable>]
type Expression = {
    V1:decimal
    Operation:Operation 
    V2:decimal
}
