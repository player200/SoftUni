function breakfastRobot() {
    let recepts = {
        apple: {
            protein: 0,
            carbohydrates: 1,
            fat: 0,
            flavours: 2
        },
        coke: {
            protein: 0,
            carbohydrates: 10,
            fat: 0,
            flavours: 20
        },
        burger: {
            protein: 0,
            carbohydrates: 5,
            fat: 7,
            flavours: 3
        },
        omelet: {
            protein: 5,
            carbohydrates: 0,
            fat: 1,
            flavours: 1
        },
        cheverme: {
            protein: 10,
            carbohydrates: 10,
            fat: 10,
            flavours: 10
        }
    }

    let currentAvalable = {
        protein: 0,
        carbohydrates: 0,
        fat: 0,
        flavours: 0
    }
    let controller = {
        restock: (microelement, quantity) => {
            if (microelement === 'carbohydrate') {
                currentAvalable['carbohydrates'] += quantity
            }
            if (microelement === 'flavour') {
                currentAvalable['flavours'] += quantity
            }
            else {
                currentAvalable[microelement] += quantity
            }
            return 'Success'
        },
        prepare: (recipe, quantity) => {
            let currentReciep = recepts[recipe]
            let neededProtein = currentReciep['protein'] * quantity
            let neededCarbs = currentReciep['carbohydrates'] * quantity
            let neededFat = currentReciep['fat'] * quantity
            let neededFlav = currentReciep['flavours'] * quantity

            if (neededProtein > currentAvalable['protein']) {
                return 'Error: not enough protein in stock'
            }
            if (neededCarbs > currentAvalable['carbohydrates']) {
                return 'Error: not enough carbohydrate in stock'
            }
            if (neededFat > currentAvalable['fat']) {
                return 'Error: not enough fat in stock'
            }
            if (neededFlav > currentAvalable['flavours']) {
                return 'Error: not enough flavour in stock'
            }

            currentAvalable['protein'] = currentAvalable['protein'] - neededProtein
            currentAvalable['carbohydrates'] = currentAvalable['carbohydrates'] - neededCarbs
            currentAvalable['fat'] = currentAvalable['fat'] - neededFat
            currentAvalable['flavours'] = currentAvalable['flavours'] - neededFlav

            return 'Success'
        },
        report: () => {
            let proteins = currentAvalable['protein']
            let carbs = currentAvalable['carbohydrates']
            let fat = currentAvalable['fat']
            let flavour = currentAvalable['flavours']
            return `protein=${proteins} carbohydrate=${carbs} fat=${fat} flavour=${flavour}`
        }
    }
    return function (command) {
        let tokens = command
            .split(' ');
        switch (tokens[0]) {
            case "restock":
                return controller.restock(tokens[1], Number(tokens[2]))
            case "prepare":
                return controller.prepare(tokens[1], Number(tokens[2]))
            case "report":
                return controller.report()
        }
    }
}