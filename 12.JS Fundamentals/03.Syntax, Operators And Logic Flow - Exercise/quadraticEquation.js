function quadraticEquation(numberA, numberB, numberC) {
    let descriminant = Math.pow(numberB, 2) - (4 * numberA * numberC)
    let firstX = (-1 * numberB + Math.sqrt(descriminant)) / (2 * numberA)
    let secondX = (-1 * numberB - Math.sqrt(descriminant)) / (2 * numberA)

    if (descriminant < 0) {
        console.log('No')
    }
    else if (descriminant === 0) {
        console.log(-1 * numberB / (2 * numberA))
    }
    else if (descriminant > 0) {
        if (firstX < secondX) {
            console.log(firstX)
            console.log(secondX)
        }
        else {
            console.log(secondX)
            console.log(firstX)
        }
    }
}

quadraticEquation(6, 11, -35)