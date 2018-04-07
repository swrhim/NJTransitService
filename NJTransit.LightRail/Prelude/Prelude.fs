namespace NJTransit.LightRail
open System

module Option =
    let inline isNull defaultValue = function Some v -> v | None -> defaultValue
    let inline getValueOrDefault (o:'a option) = isNull (Unchecked.defaultof<'a>) o
    let inline getValueOr (d : 'a) (o:'a option) = isNull d o
module Int =
    let inline tryParse (i : string) =
        match Int32.TryParse(i) with
        | (true, r) -> Some r
        | (false, _) -> None

module Float = 
    let inline tryParse (fl:string) =
        match Double.TryParse(fl) with
        | (true,fl) -> Some (float fl)
        | (false,_) -> None

[<AutoOpen>]
module Choice =
    let inline (|Success|Failure|) c = c
    let inline Success v = Choice1Of2 v
    let inline Failure e = Choice2Of2 e
    let mapl (f:'a -> 'b) = function
    | Choice1Of2 a -> f a |> Choice1Of2
    | Choice2Of2 b -> Choice2Of2 b