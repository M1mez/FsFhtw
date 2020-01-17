module HelperFunctions


open System

let intPow (a: int, b: int): int = (float a) ** (float b) |> int

// let seqToArray2D<'a> (seq: seq<'a>): 'a [,] =
//     let dimSize =
//         Math.Sqrt
//             ((seq
//               |> Seq.length
//               |> float))
//         |> int

//     let maxLength = dimSize * dimSize

//     [ 0 .. dimSize - 1 ]
//     |> Array.map (fun x -> seq.[(x * dimSize)..((x + 1) * dimSize)])
//     |> array2D


// let dimSize =
//     Math.Sqrt
//         ((seq
//           |> Seq.length
//           |> float))
//     |> int

// let maxLength = dimSize * dimSize
// if (Seq.length seq <> maxLength) then
//     failwithf "Can't convert to 2d Array, no perfect square: %i" (Seq.length seq)
// let rec buildArray2DRec (array: 'a [,], index: int): 'a [,] =
//     if (index = maxLength) then
//         array
//     else
//         let row, col = index / dimSize, index % dimSize

//         let newArray: 'a [,] =
//             array
//             |> Array2D.mapi (function
//                 | row -> fun _ -> seq.[index]
//                 | _ -> id)
//         buildArray2DRec (newArray, index + 1)
// buildArray2DRec ((Array2D.zeroCreate dimSize dimSize), 0)
