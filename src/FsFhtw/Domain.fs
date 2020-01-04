module Domain

open System.Diagnostics.CodeAnalysis

type State = int

type Message =
    | Increment
    | Decrement
    | IncrementBy of int
    | DecrementBy of int

let init(): State = 0

let update (msg: Message) (model: State): State =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1
    | IncrementBy x -> model + x
    | DecrementBy x -> model - x
// ---------------------------------------------------------------------------

// Sudoku
let sudokuSize: int = 9
let rootSize: int = 3

type RowPos =
    | LEFT = 0
    | MIDDLE = 1
    | RIGHT = 2

type ColPos =
    | UP = 0
    | MIDDLE = 1
    | DOWN = 2

type Dimension =
    | Row of RowPos
    | Col of ColPos


type Position = RowPos * ColPos

type OuterPosition = Position

type InnerPosition = Position

type Grid<'a> = List<'a * Position>

type CellState =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Empty = 0

type Cell =
    { OuterPos: OuterPosition
      InnerPos: InnerPosition
      State: CellState }

type Area = Grid<Cell>

type Board = Grid<Area>

type CreateArea = OuterPosition -> Area

type CreateBoard = Unit -> Board

type PopulateBoard = Board -> Board

type PrintBoard = Board -> Unit


//generate valid value for cell
type GenerateRandomCellValue = Unit -> int


// //check area for cell value validity
// type CheckAreaValidity = Board * Cell -> Cell option
// //check row for cell value validity
// type CheckRowValidity = Board * Cell -> Cell option
// //check col for cell value validity
// type CheckColValidity = Board * Cell -> Cell option


// add number to cell
type FillInCellValue = Board * Cell -> Board
