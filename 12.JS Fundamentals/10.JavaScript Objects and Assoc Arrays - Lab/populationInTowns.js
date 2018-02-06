function populationInTowns(arr) {
    let myMap = new Map()
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i]
            .split(' <-> ')
            .filter(w => w !== '')
        let currentCity = tokens[0]
        let currentPopulation = tokens[1]
        if (myMap.has(currentCity)) {
            myMap.set(currentCity, myMap.get(currentCity) + Number(currentPopulation))
        }
        else {
            myMap.set(currentCity, Number(currentPopulation))
        }
    }

    for (let [key, value] of myMap) {
        console.log(`${key} : ${value}`)
    }
}

populationInTowns(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'])