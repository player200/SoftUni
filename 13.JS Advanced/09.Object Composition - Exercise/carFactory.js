function carFactory(objParam) {
    let wheels = objParam['wheelsize'] % 2 === 0
        ? objParam['wheelsize'] - 1 : objParam['wheelsize']

    let power = 0
    let volume = 0
    if (objParam['power'] <= 90) {
        power = 90
        volume = 1800
    }
    else if (objParam['power'] > 90 && objParam['power'] <= 120) {
        power = 120
        volume = 2400
    }
    else if (objParam['power'] > 120 && objParam['power'] <= 200) {
        power = 200
        volume = 3500
    }

    let result = {
        model: objParam['model'],
        engine: {
            power: power,
            volume: volume
        },
        carriage: {
            type: objParam['carriage'],
            color: objParam['color']
        },
        wheels: [wheels, wheels, wheels, wheels]
    }

    return result
}

console.log(carFactory({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));