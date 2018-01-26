function stringOfNumbers(numberAsString) {
    let number = Number(numberAsString)
    let outPutString = ''

    for (let i = 1; i <= number; i++) {
        outPutString = outPutString + i
    }

    return outPutString
}

console.log(stringOfNumbers('11'))