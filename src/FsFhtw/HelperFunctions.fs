module HelperFunctions

open System
open Domain

let rnd = Random()

let bind nextFunction (optionInput: 'a option): 'a option =
    match optionInput with
    | Some s -> nextFunction s
    | None -> None

let GenerateRandomIntInRange(upper: int): int = rnd.Next(upper) + 1

let IndexToPosition(i: int): Position = Position((i / rootSize), (i % rootSize))

let IndexToAbsolutePosition(index: int): OuterPosition * InnerPosition =
    let absolutePos = index / sudokuSize, index % sudokuSize
    let outerPos: OuterPosition = ((fst absolutePos) / rootSize), ((snd absolutePos) / rootSize)
    let innerPos: InnerPosition = ((fst absolutePos) % rootSize), ((snd absolutePos) % rootSize)
    outerPos, innerPos

let PositionsToAbsolutePos(inner: InnerPosition, outer: OuterPosition): int * int =
    let row = (int (fst outer) + 1) * rootSize + (int (fst inner)) - rootSize
    let col = (int (snd outer) + 1) * rootSize + (int (snd inner)) - rootSize
    row, col

let GetCellFromIndex(index: int, board: Board): Cell =
    let absolutePos = IndexToAbsolutePosition index
    let outerPos = fst absolutePos
    let innerPos = snd absolutePos

    let area = List.find (fun x -> snd x = outerPos) board
    let cell = List.find (fun x -> snd x = innerPos) (fst area)

    fst cell
