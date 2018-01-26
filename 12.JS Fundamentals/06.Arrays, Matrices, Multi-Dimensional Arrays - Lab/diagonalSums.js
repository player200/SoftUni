function diagonalSums(matrix) {
    let firstResult = 0
    let secondResult = 0

    for (let i = 0; i < matrix.length; i++) {
        firstResult += matrix[i][i]
        secondResult += matrix[i][matrix.length - i - 1]
    }

    console.log(firstResult + ' ' + secondResult)
}

diagonalSums([[20, 40], [10, 60]])