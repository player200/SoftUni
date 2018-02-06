function townsToJSON(arr) {
    let collector = []
    for (let town of arr.splice(1)) {
        let [name, latitude, longitude] = town
            .split(/\s*\|\s*/)
            .filter(w => w !== '')
        let townObj = {
            Town: name,
            Latitude: Number(latitude),
            Longitude: Number(longitude)
        }
        collector.push(townObj)
    }
    console.log(JSON.stringify(collector))
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])