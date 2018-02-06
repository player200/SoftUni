function autoEngineeringCompany(arr) {
    let collector = {}
    for (let i = 0; i < arr.length; i++) {
        let [brand, model, qunatity] = arr[i]
            .split(' | ')
            .filter(w => w !== '')

        if (collector.hasOwnProperty(brand)) {
            if (collector[brand].hasOwnProperty(model)) {
                collector[brand][model] += Number(qunatity)
            }
            else {
                collector[brand][model] = Number(qunatity)
            }
        }
        else {
            let obj={}
            obj[model]=Number(qunatity)
            collector[brand]=obj
        }
    }

    for (let key in collector) {
        console.log(`${key}`)
        for (let prop in collector[key]) {
            console.log(`###${prop} -> ${collector[key][prop]}`)
        }
    }
}

autoEngineeringCompany(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'])