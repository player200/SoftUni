function functionalCalculator(firstDigit, secondDigit, mathSymbol) {
    if (mathSymbol === '+') {
        console.log(firstDigit + secondDigit)
    }
    else if (mathSymbol === '-') {
        console.log(firstDigit - secondDigit)
    }
    else if (mathSymbol === '/') {
        console.log(firstDigit / secondDigit)
    }
    else if (mathSymbol === '*') {
        console.log(firstDigit * secondDigit)
    }
}

functionalCalculator(2, 4, '+')