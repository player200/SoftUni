function storeCatalogue(arr) {
    let collector = {}
    for (let i = 0; i < arr.length; i++) {
        let [item, price] = arr[i]
            .split(' : ')
            .filter(w => w !== '')

        if (!collector.hasOwnProperty(item)) {
            collector[item] = Number(price)
        }
    }

    let previousKey = ''
    for (let key of Object.keys(collector).sort()) {
        let currentKey = key[0]
        if (previousKey === '' || previousKey !== currentKey) {
            console.log(currentKey)
            previousKey = currentKey
        }
        console.log(`  ${key}: ${collector[key]}`)
    }
}

storeCatalogue(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'])