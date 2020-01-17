module FileHandler

open System
open System.IO
open System.Collections
open Domain
open HelperFunctions


let stringToCellSeq (str: string): seq<Cell> =
    if (str.Length <> Constants.ALL_CELLS_SUM) then failwithf "string wrong size: %i" str.Length
    let cellSeq =
        Seq.map
            (Char.GetNumericValue
             >> int
             >> enum) str
    cellSeq

let extractAreaFromCellSeq (seq: seq<Cell>): Area option =
    if (Seq.length seq <> Constants.SUDOKU_SIZE) then failwithf "Cell Sequence wrong size: %i" (Seq.length seq)
    None

// let readSudoku(path: Path): List<RawSudoku> =
//     Seq.toList (File.ReadLines(path))

// let ReadSudoku
