
open Logic
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

    // let board = CreateBoard() |> PopulateBoard
    //in the shadows!
    let board = CreateBoard()
    let partialPopulateArea = PopulateArea board
    let area = 
      CreateArea(OuterPosition(Position(RowPos.LEFT, ColPos.UP)))
      |> partialPopulateArea

    printfn "######################################################"
    printfn "\nArea: "
    PrintArea area |> ignore
    // printfn "\nBoard: "
    // PrintBoard board    
    // printf "\nSimple Board: \n"
    // PrintBoardSimple board
    printfn "######################################################"

    // CreateBoard()
    //     |> PopulateBoard
    //     |> PrintBoardSimple         
    0 // return an integer exit code
