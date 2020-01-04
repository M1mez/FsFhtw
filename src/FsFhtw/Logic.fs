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
    List.map intToPositionWithRoot [ 0 .. 8 ]

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
    let equalCellValue (other: Cell): bool = other.State = cell.State
    let duplicates = List.where equalCellValue cells
    match duplicates.Length with
    | 0 -> Some cell
    | _ -> None

let CheckAreaValidity (area: Area) (cell: Cell) =
    let cellList = List.map fst area
    CheckForDuplicate(cellList, cell)

let CheckDimValidity(board: Board, cell: Cell, dimFunction) =
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

let CheckRowValidity (board: Board) (cell: Cell) = CheckDimValidity(board, cell, fst)

let CheckColValidity (board: Board) (cell: Cell) = CheckDimValidity(board, cell, snd)

let CopyCellWithNewValue(cell: Cell): Cell =
    { State = enum (GenerateRandomIntInRange(sudokuSize))
      OuterPos = cell.OuterPos
      InnerPos = cell.InnerPos }

let PopulateArea(area: Area, board: Board): Area =
    let rec fillCell (currCell: Cell): Cell * Position =
        let cell =
            Some(CopyCellWithNewValue(currCell))
            |> bind (CheckAreaValidity area)
            |> bind (CheckRowValidity board)
            |> bind (CheckColValidity board)
        match cell with
        | Some c -> c, c.InnerPos
        | None -> fillCell currCell
    List.map (fst >> fillCell) area

let PopulateBoard(board: Board): Board =
    let populateAndAttachPosToArea (area: Area, pos: Position): Area * Position =
        let popArea = PopulateArea(area, board)
        popArea, pos
    List.map populateAndAttachPosToArea board
