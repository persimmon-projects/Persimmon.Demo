namespace Persimmon.Demo

open Persimmon
open System

module DivideTest =

  let divide x y = x / y

  let ``simple test example`` = test "simple test exmple" {
    do! assertEquals 2 (divide 5 2)
  }

  let ``exception test example`` = test "exception test example" {
    let! e = trap { it (divide 3 0) }
    do! assertEquals  typeof<ArithmeticException> (e.GetType())
  }
