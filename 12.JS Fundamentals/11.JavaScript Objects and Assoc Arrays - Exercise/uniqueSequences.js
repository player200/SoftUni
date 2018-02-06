function uniqueSequences(arr) {
    let resultCollector = []
    for (let currentRow of arr) {
        currentRow = JSON.parse(currentRow)
        currentRow.sort((a, b) => b - a)
        let str = ''
        for (let digit of currentRow) {
            str += digit
        }
        let toString = currentRow.toString()

        if (!resultCollector.includes(toString)) {
            resultCollector.push(toString)
        }
    }

    let numberArr = []
    for (let currentArr of resultCollector) {
        let tokens = currentArr.split(',').map(Number)
        numberArr.push(tokens)
    }
    let sorted = numberArr.sort((a, b) => a.length - b.length)

    for (let currentStr of sorted) {
        console.log(`[${currentStr.join(', ')}]`)
    }

}

uniqueSequences(['[-3, -2, -1, 0, 1, 2]',
    '[10, 1, -17, 0, 2, 13]',
    '[-3, -2, 2, -1, 1, 0]'
])