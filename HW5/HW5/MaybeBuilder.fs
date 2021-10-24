module HW5.MaybeBuilder

type MaybeBuilder() =
    member b.Bind(x, f) =
        match x with
        | Ok ok -> f ok
        | Error error -> Error error
    member b.Return x  = Ok x
let maybe = MaybeBuilder()

