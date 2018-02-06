function lowestPricesInCities(arr) {
    let myMap = new Map()
    let collectionProducts = new Set()

    for (let i = 0; i < arr.length; i++) {
        let [town, product, price] = arr[i]
            .split(' | ')
            .filter(w => w !== '')
        if (myMap.has(town)) {
            if (myMap.get(town).hasOwnProperty(product)) {
                myMap.get(town)[product] = Number(price)
            }
            else {
                myMap.get(town)[product] = Number(price)
                collectionProducts.add(product)
            }
        }
        else {
            myMap.set(town, {})
            myMap.get(town)[product] = Number(price)
            collectionProducts.add(product)
        }

    }

    let currentPrice = Number.MAX_VALUE
    let currentTown = ''

    for (let currentProduct of collectionProducts) {
        for (let [key, value] of myMap) {
            if (value.hasOwnProperty(currentProduct)) {
                if (currentPrice > value[currentProduct]) {
                    currentPrice = value[currentProduct]
                    currentTown = key
                }
            }
        }

        console.log(`${currentProduct} -> ${currentPrice} (${currentTown})`)

        currentPrice = Number.MAX_VALUE
        currentTown = ''
    }
}

lowestPricesInCities(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'])
//lowestPricesInCities(['Sofia City | Audi | 100000',
//    'Sofia City | BMW | 100000',
//    'Sofia City | Mitsubishi | 10000',
//    'Sofia City | Mercedes | 10000',
//    'Sofia City | NoOffenseToCarLovers | 0',
//    'Mexico City | Audi | 1000',
//    'Mexico City | BMW | 99999',
//    'New York City | Mitsubishi | 10000',
//    'New York City | Mitsubishi | 1000',
//    'Mexico City | Audi | 100000',
//    'Washington City | Mercedes | 1000'])