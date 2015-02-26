namespace Persimmon.Demo

open Persimmon

module FizzBuzzTest =

  let fizzbuzz n =
    match (n % 3, n % 5) with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> string n

  let ``parameterize example`` =
    parameterize {
      case (1, "1")
      case (2, "2")
      case (3, "Fizz")
      case (4, "4")
      case (5, "Buzz")
      case (6, "Fizz")
      case (7, "7")
      case (8, "8")
      case (9, "Fizz")
      case (10, "Buzz")
      case (11, "11")
      case (12, "Fizz")
      case (13, "13")
      case (14, "14")
      case (15, "FizzBuzz") into (n, expected)
      run (test "fizz buzz test" {
        do! assertEquals expected (fizzbuzz n)
      })
    }
