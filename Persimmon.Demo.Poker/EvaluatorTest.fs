namespace Persimmon.Demo.Poker

open Persimmon
open Card

module EvaluatorTest =

  let onePair = [
    { Number = Number.create 1; Suit = Heart }
    { Number = Number.create 1; Suit = Spade }
    { Number = Number.create 2; Suit = Spade }
    { Number = Number.create 4; Suit = Club }
    { Number = Number.create 5; Suit = Club }
  ]

  let twoPair = [
    { Number = Number.create 1; Suit = Club }
    { Number = Number.create 2; Suit = Heart }
    { Number = Number.create 3; Suit = Diamond }
    { Number = Number.create 1; Suit = Heart }
    { Number = Number.create 2; Suit = Spade }
  ]

  let threeCards = [
    { Number = Number.create 1; Suit = Diamond }
    { Number = Number.create 2; Suit = Diamond }
    { Number = Number.create 2; Suit = Spade }
    { Number = Number.create 3; Suit = Diamond }
    { Number = Number.create 2; Suit = Heart }
  ]

  let straight1 = [
    { Number = Number.create 1; Suit = Spade }
    { Number = Number.create 2; Suit = Heart }
    { Number = Number.create 3; Suit = Club }
    { Number = Number.create 4; Suit = Diamond }
    { Number = Number.create 5; Suit = Club }
  ]

  let straight2 = [
    { Number = Number.create 10; Suit = Spade }
    { Number = Number.create 11; Suit = Heart }
    { Number = Number.create 12; Suit = Club }
    { Number = Number.create 13; Suit = Diamond }
    { Number = Number.create 1; Suit = Club }
  ]
  
  let flush = [
    { Number = Number.create 1; Suit = Heart }
    { Number = Number.create 4; Suit = Heart }
    { Number = Number.create 6; Suit = Heart }
    { Number = Number.create 9; Suit = Heart }
    { Number = Number.create 12; Suit = Heart }
  ]

  let fullHouse = [
    { Number = Number.create 1; Suit = Spade }
    { Number = Number.create 2; Suit = Heart }
    { Number = Number.create 1; Suit = Club }
    { Number = Number.create 1; Suit = Diamond }
    { Number = Number.create 2; Suit = Diamond }
  ]

  let fourCards = [
    { Number = Number.create 13; Suit = Spade }
    { Number = Number.create 1; Suit = Spade }
    { Number = Number.create 1; Suit = Club }
    { Number = Number.create 1; Suit = Heart }
    { Number = Number.create 1; Suit = Diamond }
  ]

  let straightFlush = [
    { Number = Number.create 2; Suit = Heart }
    { Number = Number.create 3; Suit = Heart }
    { Number = Number.create 4; Suit = Heart }
    { Number = Number.create 5; Suit = Heart }
    { Number = Number.create 6; Suit = Heart }
  ]

  let royalStraightFlush = [
    { Number = Number.create 10; Suit = Heart }
    { Number = Number.create 11; Suit = Heart }
    { Number = Number.create 12; Suit = Heart }
    { Number = Number.create 13; Suit = Heart }
    { Number = Number.create 1; Suit = Heart }
  ]

  let pokerHands =
    let rank =
      [ OnePair; TwoPair; ThreeCards; Straight; Straight; Flush; FullHouse; FourCards; StraightFlush; RoyalStraightFlush ]
      |> List.map Some
    let hands =
      [ onePair; twoPair; threeCards; straight1; straight2; flush; fullHouse; fourCards; straightFlush; royalStraightFlush ]
      |> List.map Hand
    List.zip hands rank

  let ``parameterize poker test`` =
    let inner (input, expected) = test "parameterize poker test" {
      do! assertEquals expected (Evaluator.evaluate input)
    }
    parameterize {
      source pokerHands
      run inner
    }