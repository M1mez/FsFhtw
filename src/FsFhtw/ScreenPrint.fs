module ScreenPrint

open Domain
open System.Console
open HelperFunctions
open Logic

// let PrintCell(cell: Cell, pos: InnerPosition): Unit =
// printf "%i" int(cell.State)

// let PrintArea(area: Area, pos: OuterPosition): Unit =

// let PrintBoard(board: Board): Unit = List.map PrintArea board |> ignore

let PrintCellWithPos(cell: Cell): Unit =
    let absolutePos = PositionsToAbsolutePos(cell.InnerPos, cell.OuterPos)
    printfn "%i ---Absolute: R%iC%i --- Outer: R%iC%i --- Inner: R%iC%i" (int cell.State) (fst absolutePos |> int)
        (snd absolutePos |> int) (fst cell.OuterPos |> int) (snd cell.OuterPos |> int) (fst cell.InnerPos |> int)
        (snd cell.InnerPos |> int)


// let PrintAreaLine(lst: List<Area>) =
//     let printCellLine(rowIndex: int) : List<Cell> =
//          printf "|"
//          lst
//          |> List.map (fun x -> int(fst x.) = rowIndex)
//          |> List.iter (fun x -> (printf "%i" (int x.State)))

//     ()

let PrintArea(area: Area) : Unit =
    let cells = List.map(fst) area
    let states = List.map(fun x -> (int) x.State) cells
    states |> Seq.iter(printf "%i ")
    printf "\n"

let PrintArea2(area: Area) : Unit =
    let cells = List.map(fst) area
    // printf " ---------"
    let printAreaRow(row: List<Cell>) = 
        printf "\n ---------\n|" 
        List.iter (fun x -> printf " %i |" (int x.State)) row 
    let getAreaRow(rowIndex: int) = 
        List.where (fun x -> int (fst x.InnerPos) = rowIndex) cells
    [0 .. rootSize - 1]
        |> List.map getAreaRow
        |> List.iter printAreaRow 
    printfn ""
    

let PrintBoardWithAreasAsRows(board: Board) : Unit =
    let areas = List.map fst board
    // List.iter(PrintArea) areas
    List.iter(PrintArea2) areas

let printLine (board: Board) (line: int) =
        //     List.map (fun x -> (Logic.GetCellFromIndex((x * sudokuSize + line) - 1, board)) |> PrintCellWithPos)
        //         [ 0 .. (sudokuSize - 1) ] |> ignore
        let getCellValueFromIndexPA(x: int) =
            (int (GetCellFromIndex((line * sudokuSize + x), board)).State)
        
        List.map (fun x -> ((getCellValueFromIndexPA) >> (printf "%i ")) x )
            [ 0 .. (sudokuSize - 1) ] |> ignore
        printfn " "

let PrintBoard(board: Board): Unit =
    // let lineValues = List.map (fun x -> int x.CellState) line
    // List.map (fun x -> printfn (x)) lineValues |> ignore
    let printLinePA = printLine board
    List.map printLinePA [ 0 .. sudokuSize - 1 ] |> ignore