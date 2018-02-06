function cappyJuice(arr) {
    let checker = {}
    let notFullChecker = {}
    for (let i = 0; i < arr.length; i++) {
        let [typeOfJuice, quantity] = arr[i]
            .split(' => ')
            .filter(w => w !== '')
        if (!notFullChecker.hasOwnProperty(typeOfJuice)) {
            notFullChecker[typeOfJuice] = 0
        }
        notFullChecker[typeOfJuice] += Number(quantity)

        let currentQuantity = notFullChecker[typeOfJuice]

        if (currentQuantity >= 1000) {
            if (!checker.hasOwnProperty(typeOfJuice)) {
                checker[typeOfJuice] = 0
            }
            let newBottles = Math.floor(currentQuantity / 1000)
            let oldBottles = checker[typeOfJuice]
            checker[typeOfJuice] = oldBottles + newBottles

            let juiceLeft = currentQuantity % 1000
            notFullChecker[typeOfJuice] = juiceLeft
        }
    }

    for (let currentObj in checker) {
        console.log(`${currentObj} => ${Math.floor(checker[currentObj])}`)
    }
}


//cappyJuice(['Orange => 2000',
//    'Peach => 1432',
//    'Banana => 450',
//    'Peach => 600',
//    'Strawberry => 549'])
cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'])