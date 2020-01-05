open CreateLogic
open Logic
open Domain
open ScreenPrint


let cell1 =
    { State = CellState.One
      OuterPos = OuterPosition(Position(0, 0))
      InnerPos = InnerPosition(Position(0, 0)) }

[<EntryPoint>]
let main argv =
    let board = CreateBoard() |> PopulateBoard
    //in the shadows!
    // let board = CreateBoard()
    // let partialPopulateArea = PopulateArea board
    // let area = 
    //   CreateArea(OuterPosition(Position(0, 0)))
    //   |> partialPopulateArea

    printfn "\n######################################################"
    // printfn "\nArea: "
    // PrintArea area |> ignore
    printfn "\nPrint Board with real Areas:"
    PrintBoard board    
    // printf "\nPrint Board with Areas as Rows: \n"
    // PrintBoardWithAreasAsRows board
    printfn "######################################################"



    // CreateBoard()
    //     |> PopulateBoard
    //     |> PrintBoardSimple         
    0 // return an integer exit code
