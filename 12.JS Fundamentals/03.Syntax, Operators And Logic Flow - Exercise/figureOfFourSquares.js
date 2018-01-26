function figureOfFourSquares(number) {
    let dashes = '-'.repeat(number - 2)
    let spaces = ' '.repeat(number - 2)
    let startCounter = number % 2 === 0 ? 1 : 0
    let endCounterDevisior = number % 2 === 0 ? 3 : 4
    console.log(`+${dashes}+${dashes}+`)
    if(number!==2){
        for (let j = startCounter; j < (number - endCounterDevisior) / 2; j++) {
            console.log(`|${spaces}|${spaces}|`)
        }

        console.log(`+${dashes}+${dashes}+`)

        for (let j = startCounter; j < (number - endCounterDevisior) / 2; j++) {
            console.log(`|${spaces}|${spaces}|`)
        }//

        console.log(`+${dashes}+${dashes}+`)
    }
}

figureOfFourSquares(5)