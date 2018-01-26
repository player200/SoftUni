function distanceOverTime(params) {
    let distanceFirst = params[0]
    let distanceSecond = params[1]
    let killometersPerHour = params[2] / 60 / 60 * 1000
    console.log(Math.abs(distanceFirst - distanceSecond) * killometersPerHour)
}

distanceOverTime([0, 60, 3600])