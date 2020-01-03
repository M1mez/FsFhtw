module Logic

open Domain


let intToPosition (rootSize: int) (i: int): Position = Position(enum i / rootSize, enum i % rootSize)

let CreateGrid(rootSize: int): List<Position> =
    let intToPositionWithRoot = intToPosition rootSize
    List.map intToPositionWithRoot [ 0 .. 8 ]

let CreateArea(positions: OuterPosition * List<InnerPosition>): Area =
    let createCellWithPos (innerPos: InnerPosition): Cell * Position =
        let cell =
            { State = CellState.Empty
              OuterPos = (fst positions)
              InnerPos = innerPos }
        (cell, innerPos)
    List.map createCellWithPos (CreateGrid rootSize)

let CreateBoard(positions: List<OuterPosition>) =
    List.map (fun (x: OuterPosition) -> CreateArea(x, (CreateGrid rootSize))) positions

// GenerateRandomCellValue()
// |> bind CheckAreaValidity
// |> bind CheckRowValidity
// |> bind CheckColValidty
// |> FillInCellValue

// let findValidNum(pos: (int * int)) :int =
