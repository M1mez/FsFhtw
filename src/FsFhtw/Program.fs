open Domain
open FileHandler
open ScreenPrint

[<EntryPoint>]
let main argv =
    let boards = 
        Constants.SUDOKU_PATH
        |> ReadSudoku
    boards.Head
        |> PrintBoard
    0 // return an integer exit code
