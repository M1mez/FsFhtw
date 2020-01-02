module Logic

let isPerfectSquare (input: string): bool =
    let parsedInput = input |> float
    let inputRoot = parsedInput |> sqrt
    let floorRoot = inputRoot |> floor
    (inputRoot - floorRoot) = float 0
