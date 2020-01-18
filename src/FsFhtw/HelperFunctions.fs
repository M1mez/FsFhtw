module HelperFunctions


open System

let IntPow(a: int, b: int): int = (float a) ** (float b) |> int

let SeqToArray2D<'a>(seq: seq<'a>): 'a [,] =
    let dimSize = Math.Sqrt((Seq.length >> float) seq) |> int
    if (Seq.length seq <> dimSize * dimSize) then
        failwithf "Can't convert to 2d Array, no perfect square: %i" (Seq.length seq)

    [ 0 .. dimSize - 1 ]
    |> Seq.map (fun x ->
        seq
        |> Seq.skip (x * dimSize)
        |> Seq.take dimSize)
    |> array2D

let GetRangeFromSequence<'a>(seq: seq<'a>, lower: int, amount: int): seq<'a> =
    (Seq.skip lower >> Seq.take amount) seq

let Flatten(A: 'a [,]) = A |> Seq.cast<'a>

let GetRowFromArray2D<'a> (row: int) (array: 'a [,]): seq<'a> = Flatten array.[row..row, *]
let GetColFromArray2D<'a> (col: int) (array: 'a [,]): seq<'a> = Flatten array.[*, col..col]

let Bind nextFunction (optionInput: 'a option): 'a option =
    match optionInput with
    | Some s -> nextFunction s
    | None -> None
