module CreateLogic

open Domain
open HelperFunctions


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