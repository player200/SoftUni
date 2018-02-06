function sumByTown(arr) {
    let objCollector = {}
    for (let i = 0; i < arr.length; i += 2) {
        let town = arr[i]
        let value = Number(arr[i + 1])
        if (objCollector.hasOwnProperty(town)) {
            objCollector[town] += value
        }
        else {
            objCollector[town] = value
        }
    }
    console.log(JSON.stringify(objCollector))
}

sumByTown(['Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4'])