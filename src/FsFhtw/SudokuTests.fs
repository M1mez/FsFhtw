module SudokuTest


open FsUnit.Xunit
open Xunit
open Logic
open Domain

[<Fact>]
let testTests() = "hallo" |> should equal "hallo"

let board = CreateBoard()
let area = CreateArea(OuterPosition(Position(RowPos.LEFT, ColPos.UP)))

let cell1 =
    { State = CellState.One
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell2 =
    { State = CellState.Two
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell3 =
    { State = CellState.Three
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell4 =
    { State = CellState.Four
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell5 =
    { State = CellState.Five
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell6 =
    { State = CellState.Six
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell7 =
    { State = CellState.Seven
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell8 =
    { State = CellState.Eight
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }

let cell9 =
    { State = CellState.Nine
      OuterPos = OuterPosition(Position(RowPos.LEFT, ColPos.UP))
      InnerPos = InnerPosition(Position(RowPos.LEFT, ColPos.UP)) }





let cells = [ cell1; cell2]


[<Fact>]
let testCheckIsDuplicateValue() =
    let result = CheckForDuplicate(cells, cell2)
    Assert.True(result.IsNone)

[<Fact>] 
let testCheckIsNotDuplicateValue() = 
    let result = CheckForDuplicate(cells, cell3)
    Assert.Equal(result.Value, cell3)

// [<Fact>]
// let testCheckAreaForInvalidCell() = 
//     ((fst (area.Item 1)).State) = CellState.One
//     ((fst (area.Item 2)).State) = CellState.Two
//     ((fst (area.Item 3)).State) = CellState.Three
//     ((fst (area.Item 4)).State) = CellState.Four
//     ((fst (area.Item 5)).State) = CellState.Five
//     ((fst (area.Item 6)).State) = CellState.One
//     ((fst (area.Item 7)).State) = CellState.One
//     ((fst (area.Item 8)).State) = CellState.One
//     ((fst (area.Item 9)).State) = CellState.One

//     let areavalidity = CheckAreaValidity area cell1
//     Assert.True(areavalidity.IsNone)

// [<Fact>]
// let testCheckAreaForValidCell() =
//     ((fst (area.Item 1)).State) = CellState.Two
//     ((fst (area.Item 2)).State) = CellState.Two
//     ((fst (area.Item 3)).State) = CellState.Three
//     ((fst (area.Item 4)).State) = CellState.Four
//     ((fst (area.Item 5)).State) = CellState.Five
//     ((fst (area.Item 6)).State) = CellState.Two
//     ((fst (area.Item 7)).State) = CellState.Two
//     ((fst (area.Item 8)).State) = CellState.Two
//     ((fst (area.Item 9)).State) = CellState.Two

//     let areavalidity = CheckAreaValidity area cell1
//     Assert.Equal(areavalidity.Value, cell1)

[<Fact>]
let testCheckAreaStepwise() = 

    let checkedCell = CheckAreaValidity area cell1
    Assert.Equal(checkedCell.Value, cell1)
    let checkedCell = CheckAreaValidity area cell2
    Assert.Equal(checkedCell.Value, cell2)
    let checkedCell = CheckAreaValidity area cell3
    Assert.Equal(checkedCell.Value, cell3)
    let checkedCell = CheckAreaValidity area cell4
    Assert.Equal(checkedCell.Value, cell4)
    let checkedCell = CheckAreaValidity area cell5
    Assert.Equal(checkedCell.Value, cell5)
    let checkedCell = CheckAreaValidity area cell6
    Assert.Equal(checkedCell.Value, cell6)
    let checkedCell = CheckAreaValidity area cell7
    Assert.Equal(checkedCell.Value, cell7)
    let checkedCell = CheckAreaValidity area cell8
    Assert.Equal(checkedCell.Value, cell8)
    let checkedCell = CheckAreaValidity area cell9
    Assert.Equal(checkedCell.Value, cell9)

    let checkedCell = CheckAreaValidity area cell1
    Assert.True(checkedCell.IsNone)
    let checkedCell = CheckAreaValidity area cell7
    Assert.True(checkedCell.IsNone)
