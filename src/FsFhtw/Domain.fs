module Domain

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


// Sudoku

type SudokuSize = int

type Position = int * int

type CellState =
    | Value of int
    | Empty



type Cell =
    { pos: Position
      state: CellState }

type Area =
    { pos: Position
      cells: List<Cell> }

type BoardState = List<Area>
