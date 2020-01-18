open Domain
open FileHandler
open ScreenPrint
open System.IO
open System
open UserInteraction

[<EntryPoint>]
let main argv =
    let boards = 
        Constants.SUDOKU_PATH
        |> ReadSudoku
    let rnd = Random()

    ChooseBoard(boards, rnd)
    |> MainLoop

    0 // return an integer exit code
