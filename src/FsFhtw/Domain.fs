module Domain
open Logic 
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


// Sudoku
let sudokuSize: int = 9
let rootSize: int = 3

type Position = int * int

type CellState = int option

type Cell() =
    let mutable state: CellState = None
    member __.State with get() : CellState = state and set(value) = state <- value
    member __.AsString() : string = 
        match state with 
        | None -> " "
        | _ -> string state.Value

type Area() =
    let cells: List<Cell * Position> = List.map (fun x -> (Cell(), x)) (CreateGrid(rootSize))
    override __.ToString() = 
        let mutable str = ""
        for i in cells do
            str <- str + ((fst i).AsString())
        str

    member __.ContainsNum(num: int) :bool =
        List.map (fun (x: Cell * Position) -> Option.defaultValue -1 ((fst x).State)) cells
        |> List.contains num

type Board() = 
    let mutable grid: List<Area * Position> = None
    member __.Inititialize() = grid <- List.map (fun x -> (Area(), x)) (CreateGrid(rootSize))
    let Board() = _.Inititialize()
    member __.PrintBoard() = 
        for el in grid do
            let str = fst el |> string
            printf "%s\n" str



