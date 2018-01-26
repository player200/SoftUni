function modifyAverage(number) {
    while (average(number) <= 5) {
        number = modifyNum(number)
    }

    console.log(number)

    function average(number) {
        let numAsArr = number.toString().split("")
        let sumDigit = numAsArr.reduce((a, b) => Number(a) + Number(b), 0)
        return sumDigit / numAsArr.length
    }

    function modifyNum(number) {
        let numAsArr = number.toString().split("")
        numAsArr.push(9)
        return numAsArr.join("")
    }
}

modifyAverage(101)