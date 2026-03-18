namespace PlayingCards

#if FABLE_COMPILER
module Array =

    open System

    /// Clones the given array.
    let clone items =
        items
            |> Seq.readonly   // force a copy
            |> Seq.toArray

    /// Shuffles the given array in place.
    /// From http://rosettacode.org/wiki/Knuth_shuffle#F.23
    let private knuthShuffle (rng : Random) (items : _[]) =
        let swap i j =
            let item = items[i]
            items[i] <- items[j]
            items[j] <- item
        let len = items.Length
        [0 .. len - 2]
            |> Seq.iter (fun i -> swap i (rng.Next(i, len)))
        items

    /// Return a new array shuffled in a random order with the specified Random instance.
    let randomShuffleWith rng items =
        knuthShuffle rng (clone items)
#endif

/// A shuffled deck of cards.
type Deck =
    {
        Cards : Card[]
    }

module Deck =

    /// Creates a shuffled deck of cards.
    let shuffle rng =
        {
            Cards =
                Array.randomShuffleWith rng Card.allCards
        }
