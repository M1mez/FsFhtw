module Logic

open System
open Domain
open DomainHelperFunctions

let LineContainsNum(line: seq<Cell>, num: int): bool = line |> Seq.contains (enum num) //enumnumnumnum

let AreaContains(area: Cell [,], num: int): bool = LineContainsNum((HelperFunctions.Flatten area), num)

let IsNumAtAbsPosValid(board: Board, pos: Position, num: int): bool =
    let row = GetBoardCellRow(board, fst pos)
    let col = GetBoardCellCol(board, snd pos)
    let area = GetAreaOfCellByAbsPos(board, pos)
    not (LineContainsNum(row, num) || LineContainsNum(col, num) || AreaContains(area, num))


let TryChangeCellState(board: Board, pos: Position, num: int): Board =
    let changeCellState(): Board =
        printfn "%i is valid!" num
        board.[fst pos, snd pos] <- (enum num)
        board

    let isValid = IsNumAtAbsPosValid(board, pos, num)
    match isValid with
    | true -> changeCellState()
    | false -> board
