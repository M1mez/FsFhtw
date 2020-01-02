module Logic

let intToPosition(rootSize: int)(i: int): (int * int) = 
   (i/rootSize, i%rootSize)

let CreateGrid(rootSize: int) : List<(int * int)> =
    let intToPositionWithRoot = intToPosition rootSize
    List.map intToPositionWithRoot [0 .. 8]

// let findValidNum(pos: (int * int)) :int =
    