// Learn more about F# at http://fsharp.org

open System
open System.Net.Http
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let app =
  choose
    [ GET >=> choose
        [ path "/hello" >=> OK "Hello GET"
          path "/goodbye" >=> OK "Good bye GET" ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST" ] ]


[<EntryPoint>]
let main argv =
    startWebServer defaultConfig app
    0 // return an integer exit code

