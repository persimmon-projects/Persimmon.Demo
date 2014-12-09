namespace Persimmon.Demo.Poker

type Hand = Hand of Card.NormalCard list
with
  member private this.String =
    match this with
    | Hand xs ->
        xs
        |> List.map string
        |> String.concat " / "
  override this.ToString () = this.String
  member this.ToString indexes =
    match this with
    | Hand xs ->
        (xs, indexes)
        ||> List.map2 (fun x y -> sprintf "[%s]:%s" y (string x))
        |> String.concat "/"

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Hand =
  let count = 5

  let tryCreateBy deck =
    Deck.tryPick count deck
    |> Option.map (fun { Deck.Picked = picked; Deck.Deck = d } -> ((Hand picked), d))

  let change (Hand xs) deck changeCards =
    Deck.tryPick (Set.count changeCards) deck
    |> Option.map (fun { Deck.Picked = picked; Deck.Deck = d } ->
        let hand = xs |> List.filter (changeCards.Contains >> not)
        Hand (List.append picked hand), d
    )
