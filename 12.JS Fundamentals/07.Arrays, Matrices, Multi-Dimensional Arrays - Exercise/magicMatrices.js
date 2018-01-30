function magicMatrices(matrix) {
    for (let row = 0; row < matrix.length - 1; row++) {
        let previousRowCount = matrix[row].reduce((a, b) => a + b)
        let currentRowCount = matrix[row + 1].reduce((a, b) => a + b)

        if (previousRowCount !== currentRowCount) {
            return false
        }

        let previousColCount = 0
        let currentColCount = 0

        for (let col = 0; col < matrix.length; col++) {
            previousColCount += matrix[col][row]
            currentColCount += matrix[col][row + 1]
        }

        if (previousColCount !== currentColCount
            || previousRowCount !== previousColCount
            || currentRowCount !== currentColCount) {
            return false
        }
    }
    return true
}

console.log(magicMatrices([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
))