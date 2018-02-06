function cityMarkets(arr) {
    let myMap = new Map()
    for (let i = 0; i < arr.length; i++) {
        let [town, product, price] = arr[i]
            .split(' -> ')
            .filter(w => w !== '')
        let currentPrice = price
            .split(' : ')
            .filter(p => p !== '')
            .reduce((a, b) => Number(a) * Number(b))

        if (myMap.has(town)) {
            myMap.get(town)[product] = currentPrice
        }
        else {
            let obj = {}
            obj[product] = currentPrice
            myMap.set(town, obj)
        }
    }

    for (let [key, values] of myMap) {
        console.log(`Town - ${key}`)
        for (let value in values) {
            console.log(`$$$${value} : ${values[value]}`)
        }
    }
}

cityMarkets(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'])