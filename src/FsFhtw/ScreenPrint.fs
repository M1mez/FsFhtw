module ScreenPrint

open Domain
open HelperFunctions
open DomainHelperFunctions

type BorderType =
    | UPPER
    | MIDDLE
    | LOWER

let private printCellRow (cells: seq<Cell>): Unit =
    let printCell (cell: Cell) =
        match cell with
        | CellState.Empty -> printf " ░"
        | _ -> printf " %i" (int cell)

    Seq.iter printCell cells

let private printVerticalBorder (borderType: BorderType) =
    let left: char =
        match borderType with
        | BorderType.UPPER -> '╔'
        | BorderType.MIDDLE -> '╠'
        | BorderType.LOWER -> '╚'

    let middle: char =
        match borderType with
        | BorderType.UPPER -> '╦'
        | BorderType.MIDDLE -> '╬'
        | BorderType.LOWER -> '╩'

    let right: char =
        match borderType with
        | BorderType.UPPER -> '╗'
        | BorderType.MIDDLE -> '╣'
        | BorderType.LOWER -> '╝'

    printfn "  %c═══════%c═══════%c═══════%c" left middle middle right

let private printCompleteCellRow (cells: seq<Cell>) (rowIndex: int): Unit =
    let indexRootSize = Constants.ROOT_SIZE - 1
    printf "%i ║" (rowIndex + 1)
    let printPartCellRow (cellsPart: seq<Cell>): Unit =
        printCellRow cellsPart
        printf " ║"
    [ for i in 0 .. indexRootSize do
        (i * Constants.ROOT_SIZE) ]
    |> Seq.iter (fun lower -> printPartCellRow (GetRangeFromSequence(cells, lower, Constants.ROOT_SIZE)))
    printf "\n"

let private printAreaRow (board: Board) (areaRowIndex: int): Unit =
    printVerticalBorder ((if areaRowIndex = 0 then BorderType.UPPER else BorderType.MIDDLE))
    [ for i in 0 .. Constants.ROOT_SIZE - 1 do
        i + (areaRowIndex * Constants.ROOT_SIZE) ]
    |> Seq.iter (fun rowIndex -> printCompleteCellRow (GetBoardCellRow(board, rowIndex)) rowIndex)

let PrintBoard(board: Board): Unit =
    printfn "    1 2 3   4 5 6   7 8 9"
    [ 0 .. Constants.ROOT_SIZE - 1 ] |> Seq.iter (printAreaRow board)
    printVerticalBorder (BorderType.LOWER)
