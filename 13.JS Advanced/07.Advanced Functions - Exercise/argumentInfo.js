function argumentInfo() {
    let collector = {}
    for (let i = 0; i < arguments.length; i++) {
        let currentArg = arguments[i]
        let type = typeof currentArg
        if (!collector.hasOwnProperty(type)) {
            collector[type] = 0
        }
        collector[type] = collector[type] + 1
        console.log(`${type}: ${currentArg}`)
    }
    function sorter(keys) {
        let outPutCollector = []
        outPutCollector.push(keys[0])
        for (let i = 1; i < keys.length; i++) {
            let prev = outPutCollector[0]
            let current = keys[i]
            let prevValue=Number(collector[prev])
            let currentValue=Number(collector[current])
            if (prevValue >= currentValue) {
                outPutCollector.push(current)
            }
            else {
                outPutCollector.unshift(current)
            }
        }
        return outPutCollector
    }
    let sorted = sorter(Object.keys(collector))



    for (let key of sorted) {
        console.log(`${key} = ${collector[key]}`)
    }
}

argumentInfo({name: 'bob'}, 3.333, 9.999)