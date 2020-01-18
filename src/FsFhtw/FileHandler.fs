module FileHandler

open System
open System.IO
open System.Collections
open Domain
open HelperFunctions

let private stringToCellSeq (str: string): seq<Cell> =
    if (str.Length <> Constants.ALL_CELLS_SUM) then failwithf "string wrong size: %i" str.Length
    let charToEnum =
        (Char.GetNumericValue
         >> int
         >> enum)
    Seq.map charToEnum str

let private extractBoardFromCellSeq (seq: seq<Cell>): Board =
    if (Seq.length seq <> Constants.ALL_CELLS_SUM) then
        failwithf "Cell Sequence wrong size for Board: %i" (Seq.length seq)
    SeqToArray2D seq

let ReadSudoku(path: Path): List<Board> =
    let sudokuStringList = File.ReadLines(path) |> Seq.toList
    let cellSequenceList = sudokuStringList |> List.map stringToCellSeq
    cellSequenceList |> List.map extractBoardFromCellSeq
