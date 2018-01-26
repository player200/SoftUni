function squareOfStars(number) {
    for (let i = 0; i < number; i++) {
        console.log('* '.repeat(number).trim())
    }
}

squareOfStars(5)