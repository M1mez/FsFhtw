module Logic

open Domain
open HelperFunctions


let CheckForDuplicate(cells: List<Cell>, cell: Cell): Cell option =
    let equalCellValue (other: Cell): bool = (int) other.State = (int) cell.State
    let duplicates = List.where equalCellValue cells

    if (duplicates.Length = 0) then
     Some cell
    else None

    // match duplicates.Length with
    // | 0 -> Some cell
    // | _ -> None

let CheckAreaValidity (area: Area) (cell: Cell) =
    let cellList = List.map fst area

    //delete
    let states = List.map (fun x -> (int) x.State) cellList
    // printf "List to check dupes against: "
    // states |> Seq.iter (printf "%i ")

    CheckForDuplicate(cellList, cell)

let ChangeCellInArea (area: Area, cell: Cell): Area =
    let func =
        (fun (x: Cell) -> if x.InnerPos = cell.InnerPos then cell, cell.InnerPos else x, x.InnerPos)
    List.map (fst >> func) area

let ChangeAreaInBoard (board: Board, newArea: Area, pos: OuterPosition) = 
    let func =
        (fun (x: Area) -> if (fst x.Head).OuterPos = pos then newArea, pos else x, (fst x.Head).OuterPos)
    List.map (fst >> func) board

let ChangeCellInBoard (board: Board, cell: Cell): Board =
    let area = List.find (fun (x: Area * OuterPosition )-> snd x = cell.OuterPos) board
    let newArea = ChangeCellInArea (fst area, cell)
    ChangeAreaInBoard (board, newArea, cell.OuterPos)

//delete
let PrintArea(area: Area) : Unit =
    let cells = List.map(fst) area
    let states = List.map(fun x -> (int) x.State) cells
    states |> Seq.iter(printf "%i ")
    printf "\n"

let printLine (board: Board) (line: int) =
        //     List.map (fun x -> (Logic.GetCellFromIndex((x * sudokuSize + line) - 1, board)) |> PrintCellWithPos)
        //         [ 0 .. (sudokuSize - 1) ] |> ignore
        let getCellValueFromIndexPA(x: int) =
            (int (GetCellFromIndex((line * sudokuSize + x), board)).State)
        
        List.map (fun x -> ((getCellValueFromIndexPA) >> (printf "%i ")) x )
            [ 0 .. (sudokuSize - 1) ] |> ignore
        printfn " "

let PrintBoard(board: Board): Unit =
    let printLinePA = printLine board
    List.map printLinePA [ 0 .. sudokuSize - 1 ] |> ignore
//to here


let CheckRowValidity(board: Board) (cell: Cell): Cell option =
    let lineIndexOfCell = (PositionsToAbsolutePos (cell.InnerPos, cell.OuterPos))
    let cellList = List.map (fun x -> GetCellFromIndex ((snd lineIndexOfCell) * sudokuSize + x, board)) [0 .. sudokuSize - 1]

    printfn "\n\n\nChecking following row: "
    cellList |> Seq.iter(fun x -> printf "%i " (int x.State))
    printfn "\n"

    CheckForDuplicate(cellList, cell)
    
let CheckColValidity(board: Board) (cell: Cell): Cell option =
    let lineIndexOfCell = (PositionsToAbsolutePos (cell.InnerPos, cell.OuterPos))
    let cellList = List.map (fun x -> GetCellFromIndex ((fst lineIndexOfCell) + x * sudokuSize, board)) [0 .. sudokuSize - 1]

    printfn "\n\n\nChecking following row: "
    cellList |> Seq.iter(fun x -> printf "%i " (int x.State))
    printfn "\n"

    CheckForDuplicate(cellList, cell)

// let CheckDimValidity(board: Board, cell: Cell, dimFunction): Cell option =
    
//     let row = (fst cell.OuterPos).ToString()
//     let col = (snd cell.OuterPos).ToString()
//     printf "val: %i " (int cell.State)
//     printf "row: %s " row    
//     printf "col: %s " col    

//     let areaLine =
//         board
//         |> List.where (fun (x: Area * OuterPosition) -> (dimFunction (snd x)) = dimFunction cell.OuterPos)
//         |> List.map fst

//     let lineIndexOfCell = fst (PositionsToAbsolutePos (cell.InnerPos, cell.OuterPos))
//     // printfn "index of line: %i" lineIndexOfCell
//     // printLine board lineIndexOfCell

//     let getCellsInLine (area: Area): List<Cell> =
//         area
//         |> List.map fst
//         |> List.where (fun x -> dimFunction x.InnerPos = dimFunction cell.InnerPos)

//     let cellList =
//         areaLine
//         |> List.map getCellsInLine
//         |> List.collect id

//     // printfn "\n\n\nBoard: "
//     // PrintBoard board
//     printf "Cells in area line: "
//     cellList |> Seq.iter(fun x -> printf "%i " (int x.State))
//     printfn ""

//     let result = CheckForDuplicate(cellList, cell)
//     if(result.IsSome) then
//         printf "Result of one validity check: %i " (int result.Value.State)
//     else
//         printf "Result of one validity check: none "
//     result

// let CheckRowValidity (board: Board) (cell: Cell): Cell option = CheckDimValidity(board, cell, fst)

// let CheckColValidity (board: Board) (cell: Cell): Cell option = CheckDimValidity(board, cell, snd)

let ChangeCellValue(cell: Cell): Cell =
    let generated = (GenerateRandomIntInRange(sudokuSize))
    //printfn "Generated Cell Value: %i " generated

    { State = enum (generated)
      OuterPos = cell.OuterPos
      InnerPos = cell.InnerPos }


// let newArea =
//     area
//     |> List.map fst
//     |> List.map changeArea
// newArea

let rec fillCell (index: int, board: Board): Cell * Position =
    let currCell = GetCellFromIndex (index, board)
    let cell = 
        Some(ChangeCellValue(currCell)) 
        // |> bind (CheckAreaValidity area)
        |> bind (CheckRowValidity board)
        // |> bind (CheckColValidity board)

    match cell with
    | Some c -> (c, c.InnerPos)
    | None -> (fillCell (index, board))

let PopulateArea (board: Board) (area: Area): Board =
    let updateAreaWithNewCell (index: int, func, area: Area): Area =
        let pos = IndexToPosition index

        let changeArea =
            (fun (x: Cell) -> if x.InnerPos = pos then func x else x, x.InnerPos)
        List.map (fst >> changeArea) area

    let rec populateNextCell (index: int) (b: Board): Board =
        if (index = sudokuSize)
        then a
        else ChangeCellInBoard (index, (fillCell (a, b)), a) |> (populateNextCell (index + 1))

    populateNextCell 0 area

let PopulateBoard(board: Board): Board =
    let updateBoardWithNewArea (index: int, b: Board): Board = 
        let pos = IndexToPosition index
        let area = fst (List.find (fun (x: Area * OuterPosition) -> snd x = pos) b)
        PopulateArea board area
        
        //ChangeAreaInBoard (b, (PopulateArea b area), pos)

    let rec populateNextArea (index: int) (b: Board) =
        if (index = sudokuSize)
        then b
        else updateBoardWithNewArea (index, b) |> (populateNextArea (index + 1))

    populateNextArea 0 board

    // let populateAndAttachPosToArea (area: Area, pos: Position): Area * Position =
    //     let popArea = PopulateArea board area
    //     popArea, pos
    // List.map populateAndAttachPosToArea board