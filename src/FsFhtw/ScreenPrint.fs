module ScreenPrint

open Domain
open System.Console
open HelperFunctions

// let PrintCell(cell: Cell, pos: InnerPosition): Unit =
// printf "%i" int(cell.State)

// let PrintArea(area: Area, pos: OuterPosition): Unit =

// let PrintBoard(board: Board): Unit = List.map PrintArea board |> ignore

let PrintCellWithPos(cell: Cell): Unit =
    let absolutePos = PositionsToAbsolutePos(cell.InnerPos, cell.OuterPos)
    printfn "%i ---Absolute: R%iC%i --- Outer: R%iC%i --- Inner: R%iC%i" (int cell.State) (fst absolutePos |> int)
        (snd absolutePos |> int) (fst cell.OuterPos |> int) (snd cell.OuterPos |> int) (fst cell.InnerPos |> int)
        (snd cell.InnerPos |> int)



let PrintBoard(board: Board): Unit =
    // let areasInLine =
    //     board
    //     |> List.where (fun (x: Area * OuterPosition) -> (fst (snd x)) = line)
    //     |> List.map fst
    // let getCellsInLine (area: Area): List<Cell> =
    //     area
    //     |> List.map fst
    //     |> List.where (fun x -> fst x.InnerPos = line)

    // let line =
    //     areasInLine
    //     |> List.map getCellsInLine
    //     |> List.collect id

    // let lineValues = List.map (fun x -> int x.CellState) line

    // List.map (fun x -> printfn (x)) lineValues |> ignore

    let printLine (line: int) =
        //     List.map (fun x -> (Logic.GetCellFromIndex((x * sudokuSize + line) - 1, board)) |> PrintCellWithPos)
        //         [ 0 .. (sudokuSize - 1) ] |> ignore

        List.map (fun x -> printf "%i" (int (Logic.GetCellFromIndex((x * sudokuSize + line) - 1, board)).State))
            [ 0 .. (sudokuSize - 1) ] |> ignore
        printfn " "

    List.map printLine [ 1 .. sudokuSize ] |> ignore


// let PrintBoard(board: Board) : Unit =






//Cell

// member __.State
//     with get (): CellState = state
//     and set (value) = state <- value

// member __.AsString(): string =
//     match state with
//     | None -> " "
//     | _ -> string state.Value



//Area

// type Area() =
//     let cells: Grid<CellState> =
//         (CreateGrid(rootSize))
//         |> List.map (fun (x: Position) -> (CellState.Empty, x))

//     // override __.ToString() =
//     //     let mutable str = ""
//     //     for i in cells do
//     //         str <- str + ((fst i).AsString())
//     //     str

//     member __.ContainsNum(num: int): bool =
//         List.map (fun (x: Cell * Position) -> Option.defaultValue -1 ((fst x).State)) cells |> List.contains num

//Board
// let mutable grid: List<Area * Position>
// let Board() = __.Inititialize()
// member __.Inititialize() = grid <- List.map (fun x -> (Area(), x)) (CreateGrid(rootSize))
// member __.PrintBoard() =
//     for el in grid do
//         let str = fst el |> string
//         printf "%s\n" str
