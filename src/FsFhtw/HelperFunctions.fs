module HelperFunctions

open System
open Domain

let rnd = Random()

let bind nextFunction (optionInput: 'a option): 'a option =
    match optionInput with
    | Some s -> nextFunction s
    | None -> None

let GenerateRandomIntInRange(upper: int): int = rnd.Next(upper - 1) + 1

let IndexToPosition(i: int): Position = Position(enum (i / rootSize), enum (i % rootSize))

let IndexToAbsolutePosition(index: int): OuterPosition * InnerPosition =
    let absolutePos = index / sudokuSize, index % sudokuSize
    let outerPos: OuterPosition = enum ((fst absolutePos) / rootSize), enum ((snd absolutePos) / rootSize)
    let innerPos: InnerPosition = enum ((fst absolutePos) % rootSize), enum ((snd absolutePos) % rootSize)
    outerPos, innerPos

let PositionsToAbsolutePos(inner: InnerPosition, outer: OuterPosition): int * int =
    let row = (int (fst outer) + 1) * rootSize + (int (fst inner)) - rootSize
    let col = (int (snd outer) + 1) * rootSize + (int (snd inner)) - rootSize
    row, col
