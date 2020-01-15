module SudokuTest

// // open Swensen.Unquote
// open FsUnit.Xunit
// open Xunit
// open Xunit.Abstractions
// open Logic
// open Domain
// open ScreenPrint
// open CreateLogic


// let cell1 =
//     { State = CellState.One
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell2 =
//     { State = CellState.Two
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell3 =
//     { State = CellState.Three
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell4 =
//     { State = CellState.Four
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell5 =
//     { State = CellState.Five
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell6 =
//     { State = CellState.Six
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell7 =
//     { State = CellState.Seven
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell8 =
//     { State = CellState.Eight
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }

// let cell9 =
//     { State = CellState.Nine
//       OuterPos = OuterPosition(Position(0, 0))
//       InnerPos = InnerPosition(Position(0, 0)) }


// [<Fact>]
// let ``test check is duplicate value``() =
//     let cells = [ cell1; cell2; cell3;cell4;cell5;cell6;cell7;cell8;cell9]
//     let result = CheckForDuplicate(cells, cell2)
//     Assert.True(result.IsNone)
//     let result = CheckForDuplicate(cells, cell7)
//     Assert.True(result.IsNone)
//     let result = CheckForDuplicate(cells, cell8)
//     Assert.True(result.IsNone)
//     let result = CheckForDuplicate(cells, cell9)
//     Assert.True(result.IsNone)

// [<Fact>] 
// let ``test check is not duplicate value``() = 
//     let cells = [ cell1; cell2; cell3;cell4;cell5;cell6;cell7]

//     let result = CheckForDuplicate(cells, cell8)
//     Assert.Equal(result.Value, cell8)

//     let result = CheckForDuplicate(cells, cell9)
//     Assert.Equal(result.Value, cell9)

//     let result = CheckForDuplicate(cells, cell1)
//     Assert.True(result.IsNone)

// [<Fact>]
// let ``test area validity stepwise``() = 
//     let board = CreateBoard()
//     let partialPopulateArea = PopulateArea board
//     let area = 
//       CreateArea(OuterPosition(Position(0, 0)))
//       |> partialPopulateArea

//     let checkedCell = CheckAreaValidity area cell1
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell2
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell3
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell4
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell5
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell6
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell7
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell8
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckAreaValidity area cell9
//     Assert.True(checkedCell.IsNone)

// [<Fact>]
// let ``test check row validity``() =
//     let board = PopulateBoard (CreateBoard()) 
//     let checkedCell = CheckRowValidity board cell1
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell2
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell3
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell4
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell5
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell6
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell7
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell8
//     Assert.True(checkedCell.IsNone)
//     let checkedCell = CheckRowValidity board cell9
//     Assert.True(checkedCell.IsNone)
    






// type SudokuTestsTry(output: ITestOutputHelper) =
//   [<Fact>]
//   member __.``SomeFunction should return 10`` () =
//         let a = (fun () -> 10)
//         output.WriteLine("Some funcASDASDKJHASKFJBAGJABKGBAJDBAJKSDBKJBASKJDBKJASBJKDBKASJBDKJABSDKJBASKJDBKJASBKDJBJKASBKDJBASKJDBtion returned {0}", a)
//         Assert.True(true)
