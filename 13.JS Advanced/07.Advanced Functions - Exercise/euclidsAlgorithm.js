function euclidsAlgorithm(firstNumber,secondNumber)
{
    while (secondNumber !== 0) {
        let previousNumber = secondNumber
        secondNumber = firstNumber % secondNumber
        firstNumber = previousNumber
    }

    return firstNumber
}

console.log(euclidsAlgorithm(252, 105));