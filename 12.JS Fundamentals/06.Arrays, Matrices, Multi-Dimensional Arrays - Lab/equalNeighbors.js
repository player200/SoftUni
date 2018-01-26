function equalNeighbors(matrix) {
    let neighbors = 0
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row === matrix.length - 1) {
                if (matrix[row][col] == matrix[row][col + 1]) {
                    neighbors++
                }
            }
            else {
                if (matrix[row][col] == matrix[row][col + 1]) {
                    neighbors++
                }

                if (matrix[row][col] == matrix[row + 1][col]) {
                    neighbors++
                }
            }

        }
    }

    return neighbors
}

//console.log(equalNeighbors([
//   ['test', 'yes', 'yo', 'ho'],
//   ['well', 'done', 'yo', '6'],
//   ['not', 'done', 'yet', '5']]))

console.log(equalNeighbors([
    [2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]
))