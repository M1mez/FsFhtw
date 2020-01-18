module SudokuTest

open FsUnit.Xunit
open Xunit
open Xunit.Abstractions
open Logic
open Domain
open ScreenPrint
open FileHandler
open DomainHelperFunctions

let private stringZerosBeginsWithOne = "1" + (String.replicate 80 "0")

let private board =
    stringZerosBeginsWithOne
    |> StringToCellSeq
    |> ExtractBoardFromCellSeq

let firstRow = GetBoardCellRow(board, 0)
let secondRow = GetBoardCellRow(board, 1)
let firstCol = GetBoardCellCol(board, 0)
let secondCol = GetBoardCellCol(board, 1)
let firstArea = GetAreaOfCellByAbsPos(board, (0, 0))
let secondArea = GetAreaOfCellByAbsPos(board, (0, 4))

[<Fact>]
let ``That Value is duplicate in row``() =
    let isDuplicate = LineContainsNum(firstRow, 1)
    isDuplicate |> should be True

[<Fact>]
let ``That Value is NOT duplicate in row``() =
    let isDuplicate = LineContainsNum(secondRow, 1)
    isDuplicate |> should be False

[<Fact>]
let ``That Value is duplicate in col``() =
    let isDuplicate = LineContainsNum(firstCol, 1)
    isDuplicate |> should be True

[<Fact>]
let ``That Value is NOT duplicate in col``() =
    let isDuplicate = LineContainsNum(secondCol, 1)
    isDuplicate |> should be False

[<Fact>]
let ``That Value is duplicate in area``() =
    let isDuplicate = AreaContains(firstArea, 1)
    isDuplicate |> should be True

[<Fact>]
let ``That Value is NOT duplicate in area``() =
    let isDuplicate = AreaContains(secondArea, 1)
    isDuplicate |> should be False

[<Fact>]
let ``That Value is NOT duplicate``() =
    let isDuplicate = IsNumAtAbsPosValid(board, (0, 1), 2)
    isDuplicate |> should be False

[<Fact>]
let ``That Value is duplicate``() =
    let isDuplicate = IsNumAtAbsPosValid(board, (8, 0), 1)
    isDuplicate |> should be True
