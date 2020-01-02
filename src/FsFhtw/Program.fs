[<EntryPoint>]
let main argv =
    // printfn "Welcome to the FHTW Domain REPL!"
    // printfn "Please enter your commands to interact with the system."
    // printfn "Press CTRL+C to stop the program."
    // printf "> "

    // let initialState = Domain.init ()
    // Repl.loop initialState

    printfn "%b" (Logic.isPerfectSquare "5")
    printfn "%b" (Logic.isPerfectSquare "9")
    printfn "%b" (Logic.isPerfectSquare "16")
    printfn "%b" (Logic.isPerfectSquare "7")
    printfn "%b" (Logic.isPerfectSquare "625")
    printfn "%b" (Logic.isPerfectSquare "624")


    0 // return an integer exit code
