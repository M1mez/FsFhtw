module Logic

open Domain
open HelperFunctions


let GetCellFromIndex(index: int, board: Board): Cell =
    let absolutePos = IndexToAbsolutePosition index
    let outerPos = fst absolutePos
    let innerPos = snd absolutePos

    let area = List.find (fun x -> snd x = outerPos) board
    let cell = List.find (fun x -> snd x = innerPos) (fst area)

    fst cell

let CreateGrid(rootSize: int): List<Position> =
    let intToPositionWithRoot = IndexToPosition
    List.map intToPositionWithRoot [ 0 .. (sudokuSize - 1) ]

let CreateArea(outerPos: OuterPosition): Area =
    let createCellWithPos (innerPos: InnerPosition): Cell * Position =
        let cell =
            { State = CellState.Empty
              OuterPos = outerPos
              InnerPos = innerPos }
        (cell, innerPos)
    List.map createCellWithPos (CreateGrid rootSize)

let CreateBoard(): Board =
    let positions = CreateGrid rootSize

    let createAreaPosTuple (outerPos: OuterPosition): Area * Position =
        let area = CreateArea outerPos
        (area, outerPos)
    List.map createAreaPosTuple positions

let CheckForDuplicate(cells: List<Cell>, cell: Cell): Cell option =
    let equalCellValue (other: Cell): bool = (int) other.State = (int) cell.State
    let duplicates = List.where equalCellValue cells

    match duplicates.Length with
    | 0 -> Some cell
    | _ -> None

let CheckAreaValidity (area: Area) (cell: Cell) =
    let cellList = List.map fst area

    //delete
    let states = List.map (fun x -> (int) x.State) cellList
    printf "List to check dupes against: "
    states |> Seq.iter (printf "%i ")

    CheckForDuplicate(cellList, cell)

//delete
let PrintArea(area: Area): Unit =
    let cells = List.map (fst) area
    let states = List.map (fun x -> (int) x.State) cells
    states |> Seq.iter (printf "%i ")
    printf "\n"

let CheckDimValidity(board: Board, cell: Cell, dimFunction): Cell option =
    let areaLine =
        board
        |> List.where (fun (x: Area * OuterPosition) -> (dimFunction (snd x)) = dimFunction cell.OuterPos)
        |> List.map fst

    let getCellsInLine (area: Area): List<Cell> =
        area
        |> List.map fst
        |> List.where (fun x -> dimFunction x.InnerPos = dimFunction cell.InnerPos)

    let line =
        areaLine
        |> List.map getCellsInLine
        |> List.collect id

    CheckForDuplicate(line, cell)

let CheckRowValidity (board: Board) (cell: Cell): Cell option = CheckDimValidity(board, cell, fst)

let CheckColValidity (board: Board) (cell: Cell): Cell option = CheckDimValidity(board, cell, snd)

let ChangeCellValue(cell: Cell): Cell =
    let generated = (GenerateRandomIntInRange(sudokuSize))
    printfn "Generated Cell Value: %i " generated

    { State = enum (generated)
      OuterPos = cell.OuterPos
      InnerPos = cell.InnerPos }


// let newArea =
//     area
//     |> List.map fst
//     |> List.map changeArea
// newArea

let rec fillCell (area: Area, board: Board) (currCell: Cell): Cell * Position =
    let cell = Some(ChangeCellValue(currCell)) |> bind (CheckAreaValidity area)
    // |> bind (CheckRowValidity board)
    // |> bind (CheckColValidity board)

    match cell with
    | Some c -> (c, c.InnerPos)
    | None -> (fillCell (area, board) currCell)

let PopulateArea (board: Board) (area: Area): Area =
    let updateCellWithPos (index: int, func, area: Area): Area =
        let pos = IndexToPosition index

        let changeArea =
            (fun (x: Cell) -> if x.InnerPos = pos then func x else x, x.InnerPos)
        List.map (fst >> changeArea) area

    let rec populateNextCell (index: int) (a: Area) =
        if (index = sudokuSize)
        then a
        else updateCellWithPos (index, (fillCell (a, board)), a) |> (populateNextCell (index + 1))

    populateNextCell 0 area

let PopulateAreaNOT (board: Board) (area: Area): Area =
    let currentCell =
        { State = CellState.Empty
          OuterPos = RowPos.LEFT, ColPos.UP
          InnerPos = RowPos.LEFT, ColPos.UP }

    let filledCell = (fillCell (area, board) currentCell)
    //append correct cell to area
    //do again for next cell in area == do again for next innerpos
    //-> iterate implicitly over innerpositions



    area



// area
//     |> List.map fst
//     |> List.map (fun x -> fillCell(x))
// List.map (fst >> fillCell) area"








// let PopulateAreaIMPROVED (board: Board) (area: Area): Area =
//     //needs to modify the current area
//     printf "improvedly populate the following area: "
//     PrintArea area //empty area - this is ok

//     let rec fillCell (currCell: Cell, usedCells: List<Cell>): Cell * Position =
//         printf "filling cell for the following area: "
//         PrintArea area //empty area - only ok for the first iteration
//         let cell =
//             Some(CopyCellWithNewValue(currCell))
//             |> bind (CheckAreaValidity area)
//             // |> bind (CheckRowValidity board)
//             // |> bind (CheckColValidity board)
//         if (cell = None) then printfn "cell was none"
//         if (cell.IsSome) then
//             printfn "State: %i" (int (cell.Value.State))
//             printfn "Inner: R%iC%i" (int (fst cell.Value.InnerPos)) (int (snd cell.Value.InnerPos))
//             printfn "Outer: R%iC%i" (int (fst cell.Value.OuterPos)) (int (snd cell.Value.OuterPos))

//         match cell with
//         | Some c -> (c, c.InnerPos) //return the found cell
//         | None -> List.fold(fun x -> fillCell(currCell, (fst x)) usedCells
//             // ((fillCell(currCell, area)) //do again -> but with a new area!

//     area
//         |> List.map fst
//         |> List.map (fun x -> fillCell(x, area))
//     // List.map (fst >> fillCell) area


let PopulateBoard(board: Board): Board =
    let populateAndAttachPosToArea (area: Area, pos: Position): Area * Position =
        let popArea = PopulateArea board area
        popArea, pos
    List.map populateAndAttachPosToArea board
