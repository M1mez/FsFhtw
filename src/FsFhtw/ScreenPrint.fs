//Cell
    
    // member __.State
    //     with get (): CellState = state
    //     and set (value) = state <- value

    // member __.AsString(): string =
    //     match state with
    //     | None -> " "
    //     | _ -> string state.Value



//Area

// type Area() =
//     let cells: Grid<CellState> = 
//         (CreateGrid(rootSize))
//         |> List.map (fun (x: Position) -> (CellState.Empty, x))

//     // override __.ToString() =
//     //     let mutable str = ""
//     //     for i in cells do
//     //         str <- str + ((fst i).AsString())
//     //     str

//     member __.ContainsNum(num: int): bool =
//         List.map (fun (x: Cell * Position) -> Option.defaultValue -1 ((fst x).State)) cells |> List.contains num

//Board
    // let mutable grid: List<Area * Position> 
    // let Board() = __.Inititialize()
    // member __.Inititialize() = grid <- List.map (fun x -> (Area(), x)) (CreateGrid(rootSize))
    // member __.PrintBoard() =
    //     for el in grid do
    //         let str = fst el |> string
    //         printf "%s\n" str