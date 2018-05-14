module Persimmon.Demo.Poker.Evaluator

let perms = List.permutation [0..(Hand.count - 1)]

let evaluate' evals (Hand cards) =
  let handPerms =
    perms
    |> List.map (List.map (fun i -> cards.[i]))

  handPerms
  |> List.map (fun x ->
      evals
      |> List.map (fun f -> f x)
      |> List.choose id
  )

let evaluate hand =
  evaluate' Evaluation.evaluations hand
  |> List.map List.tryMax
  |> List.choose id
  |> List.tryMax
