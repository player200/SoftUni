function roadRadar(params) {
    let speed=Number(params[0])
    let road=params[1]
    function limit(zone) {
        switch (zone) {
            case 'motorway':
                return 130
            case 'interstate':
                return 90
            case 'city':
                return 50
            case 'residential':
                return 20
        }
    }

    let speedLimit = limit(road)
    let overSpeed = speed - speedLimit

    if (overSpeed > 0 && overSpeed <= 20) {
        return "speeding"
    }
    else if (overSpeed > 20 && overSpeed <= 40) {
        return "excessive speeding"
    }
    else if (overSpeed > 40) {
        return "reckless driving"
    }
    else {
        return ""
    }
}

console.log(roadRadar([21, 'residential']))