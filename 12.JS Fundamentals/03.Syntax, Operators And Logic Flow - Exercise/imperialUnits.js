function imperialUnits(number) {
    let foots = Math.floor(number / 12)
    let inches = number % 12
    console.log(`${foots}'-${inches}"`)
}

imperialUnits(55)