module Persimmon.Demo.Poker.Evaluation

type private Cards = Card.NormalCard list

let onePair (cards: Cards) =
  cards.[0].Number = cards.[1].Number

let threeCards (cards: Cards) =
  (onePair cards)
    && cards.[1].Number = cards.[2].Number

let fourCards (cards: Cards) =
  (threeCards cards)
    && cards.[2].Number = cards.[3].Number

let twoPair (cards: Cards) =
  (onePair cards)
    && cards.[1].Number <> cards.[2].Number
    && cards.[2].Number = cards.[3].Number

let fullHouse (cards: Cards) =
  (threeCards cards)
    && cards.[2].Number <> cards.[3].Number
    && cards.[3].Number = cards.[4].Number

let straight (cards: Cards) =
  cards
  |> Seq.pairwise
  |> Seq.forall (fun (x, y) -> x.Number ++ 1 = y.Number)

let flush (cards: Cards) =
  cards
  |> Seq.pairwise
  |> Seq.forall (fun (x, y) -> x.Suit = y.Suit)

let straightFlush (cards: Cards) =
  (straight cards) && (flush cards)

let royalStraightFlush (cards: Cards) =
  (straightFlush cards) && (
    let royal = [10..13]@[1]
    (cards |> List.map (fun x -> x.Number |> Card.Number.value)) = royal
  )

let map =
  Map.ofList [
    (OnePair, onePair); (ThreeCards, threeCards); (FourCards, fourCards)
    (TwoPair, twoPair); (FullHouse, fullHouse); (Straight, straight)
    (Flush, flush); (StraightFlush, straightFlush); (RoyalStraightFlush, royalStraightFlush)
  ]

let evaluations =
  map
  |> Map.toList
  |> List.map (fun (key, f) xs -> if f xs then Some key else None)
