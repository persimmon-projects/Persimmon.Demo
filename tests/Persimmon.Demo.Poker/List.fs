module Persimmon.Demo.Poker.List

let trySplitAt count list =
  let rec loop i acc tail =
    if i = count then Some ((List.rev acc), tail)
    else match tail with
         | [] -> None
         | h::t -> loop (i + 1) (h::acc) t
  loop 0 [] list

let difference xs ys =
  let ys = Set.ofList ys
  xs |> List.filter (ys.Contains >> not)

let permutation xs =
  let rec loop xs current acc =
    match xs with
    | [] -> current::acc
    | xs -> List.foldBack (fun x state -> loop (difference xs [x]) (x::current) state) xs acc
  loop xs [] []
  |> List.map List.rev

let tryMax = function
| [] -> None
| xs -> List.max xs |> Some
