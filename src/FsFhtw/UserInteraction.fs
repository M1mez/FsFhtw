module UserInteraction

open System
open Domain
open ScreenPrint
open Logic
open System.Collections

let rec PromptInput(message: string, init: string, possible: seq<int>): int =
    printf "%s%s" message init
    let input = Console.ReadLine()
    let (couldParse, number) = System.Int32.TryParse input
    let ok = couldParse && possible |> Seq.contains number

    match ok with
    | true -> number
    | false -> PromptInput("Please provide only valid numbers for ", init, possible)

let rec MainLoop(board: Board): Unit =
    Console.Clear()
    PrintBoard board
    let newBoard: Board = Array2D.copy board
    let row = PromptInput("", "Row: ", [ 1 .. Constants.SUDOKU_SIZE ]) - 1
    let col = PromptInput("", "Col: ", [ 1 .. Constants.SUDOKU_SIZE ]) - 1
    let num = PromptInput("", "Cell Number: ", [ 1 .. Constants.SUDOKU_SIZE ])

    TryChangeCellState(board, (row, col), num) |> MainLoop

let rec ChooseBoard(boards: seq<Board>, rnd: Random): Board =
    let boardIndex: int = rnd.Next() % (Seq.length boards)
    let currentBoard: Board = Seq.item boardIndex boards

    let rec satisfying (board: Board): Board =
        Console.Clear()
        PrintBoard currentBoard
        printf "Is this board satisfying? [y/n]"
        let input = Console.ReadLine()
        match input with
        | "Yes"
        | "yes"
        | "Y"
        | "y" -> currentBoard
        | "No"
        | "no"
        | "N"
        | "n" -> ChooseBoard(boards, rnd)
        | _ -> satisfying (currentBoard)
    satisfying (currentBoard)
