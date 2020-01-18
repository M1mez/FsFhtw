module DomainHelperFunctions

open Domain
open HelperFunctions


let IndexToPosition(i: int, dimSize): int * int = (i / dimSize), (i % dimSize)
let GetOuterPosFromAbsolutePos(pos: int * int): int * int =
    fst pos / Constants.ROOT_SIZE, snd pos / Constants.ROOT_SIZE
let GetInnerPosFromAbsolutePos(pos: int * int): int * int =
    fst pos % Constants.ROOT_SIZE, snd pos % Constants.ROOT_SIZE

let GetBoardCellCol(board: Board, colNumber: int): seq<Cell> = GetColFromArray2D colNumber board
let GetBoardCellRow(board: Board, rowNumber: int): seq<Cell> = GetRowFromArray2D rowNumber board

let GetAreaOfCellByAbsPos(board: Board, absolutePos: Position) =
    let areaOriginPosX = (fst absolutePos) - ((fst absolutePos) % Constants.ROOT_SIZE)
    let areaOriginPosY = (snd absolutePos) - ((snd absolutePos) % Constants.ROOT_SIZE)
    board.[areaOriginPosX..areaOriginPosX + Constants.ROOT_SIZE - 1, areaOriginPosY..areaOriginPosY
                                                                                     + Constants.ROOT_SIZE - 1]

let GetAreaOfCellByAbsIndex(board: Board, absoluteIndex: int) =
    GetAreaOfCellByAbsPos(board, (IndexToPosition(absoluteIndex, Constants.ROOT_SIZE)))
