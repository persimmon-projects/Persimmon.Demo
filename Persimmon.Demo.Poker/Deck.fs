module Persimmon.Demo.Poker.Deck

let deckWithoutJoker =
  List.ofSeq (seq {
    for num in Card.Number.min .. Card.Number.max do
    for suit in Card.Suit.values ->
      { Card.Number = Card.Number.create num; Card.Suit = suit }
  })

let shuffle deck =
  deck |> Seq.sortBy (fun _ -> System.Guid.NewGuid())

type PickResult = { Picked: Card.NormalCard list; Deck: Card.NormalCard list }

let tryPick count deck =
  List.trySplitAt count deck
  |> Option.map (fun (head, tail) -> { Picked = head; Deck = tail })
