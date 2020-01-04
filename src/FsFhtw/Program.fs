﻿open Logic
open Domain
open ScreenPrint

[<EntryPoint>]
let main argv =
    // printfn "Welcome to the FHTW Domain REPL!"
    // printfn "Please enter your commands to interact with the system."
    // printfn "Press CTRL+C to stop the program."
    // printf "> "

    // let initialState = Domain.init ()
    // Repl.loop initialState
 
    CreateBoard()
    |> PopulateBoard
    |> PrintBoard


    0 // return an integer exit code
