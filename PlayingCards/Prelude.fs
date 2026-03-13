namespace PlayingCards

open System

module Enum =

    /// Answers all values of the given enum type.
    let inline getValues<'enum> =
        Enum.GetValues(typeof<'enum>)
            |> Seq.cast<'enum>
            |> Seq.toArray
