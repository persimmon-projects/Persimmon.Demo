module Persimmon.Demo.Poker.Card

type Suit = Spade | Heart | Diamond | Club

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Suit =
  let values = [Spade; Heart; Diamond; Club]

type Number = private {
  Value: int
}
with
  static member Min = 1
  static member Max = 13
  override this.ToString() = string this.Value
  static member (++) (l: Number, r: int) =
    let rec loop value =
      if value > Number.Max then loop (value - Number.Max + Number.Min - 1)
      else value
    let l = l.Value
    let value = l + r
    { Value = loop value }

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Number =
  let min = Number.Min
  let max = Number.Max

  let value x = x.Value
  let create x =
    if not (min <= x && x <= max) then
      failwith "The Number is required 1 to 13."
    { Value = x }

type NormalCard = {
  Number: Number
  Suit: Suit
}
with
  override this.ToString() = sprintf "%A%d" this.Suit (this.Number |> Number.value)
