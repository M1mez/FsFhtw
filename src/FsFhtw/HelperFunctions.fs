module HelperFunctions

open System

let rnd = Random()

let bind nextFunction (optionInput: 'a option): 'a option =
    match optionInput with
    | Some s -> nextFunction s
    | None -> None

let GenerateRandomIntInRange(upper: int): int = rnd.Next(upper - 1) + 1
