open Domain

[<EntryPoint>]
let main argv =
    let fullArray = [| 1 .. 100 |]

    // Create a slice from indices 1-5 (inclusive)
    let smallSlice = fullArray.[1..5]
    printfn "Small slice: %A" smallSlice
    0 // return an integer exit code
