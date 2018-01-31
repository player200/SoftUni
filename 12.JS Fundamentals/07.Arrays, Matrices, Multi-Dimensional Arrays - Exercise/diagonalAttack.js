function diagonalAttack(matrix) {
    let firstDiagonal = 0
    let secondDiagonal = 0
    let currentMatrix = []
    for (let row = 0; row < matrix.length; row++) {
        currentMatrix[row] = matrix[row]
            .split(' ')
            .map(item => parseInt(item))

        firstDiagonal += currentMatrix[row][row]
    }

    for (let row = matrix.length - 1; row >= 0; row--) {
        secondDiagonal += currentMatrix[row][matrix.length - 1 - row]
    }

    if (firstDiagonal === secondDiagonal) {
        for (let row = 0; row < currentMatrix.length; row++) {
            for (let col = 0; col < currentMatrix[row].length; col++) {
                if(isInDiagonal(row, col, currentMatrix)){
                    currentMatrix[row][col]=firstDiagonal
                }
            }
        }

        printer(currentMatrix)
    }
    else {
        printer(currentMatrix)
    }

    function printer(currentMatrix) {
        for (let row = 0; row < currentMatrix.length; row++) {
            console.log(currentMatrix[row].join(' '))
        }
    }

    function isInDiagonal(r, c, matrix) {
        for (let row = 0; row < matrix.length; row++) {
            if (r === row && c === row) {
                return false
            }
        }

        for (let row = matrix.length - 1; row >= 0; row--) {
            if (row === r && matrix.length - 1 - row === c) {
                return false
            }
        }

        return true
    }
}

diagonalAttack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
)