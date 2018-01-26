function insideVolume(params) {
    for (let i = 0; i < params.length; i += 3) {
        let x = params[i]
        let y = params[i + 1]
        let z = params[i + 2]

        if (inVolume(x, y, z)) {
            console.log('inside')
        }
        else{
            console.log('outside')
        }
    }

    function inVolume(x, y, z) {
        let x1 = 10, x2 = 50
        let y1 = 20, y2 = 80
        let z1 = 15, z2 = 50

        return (x >= x1 && x <= x2 && y >= y1 && y <= y2 && z >= z1 && z <= z2)
    }
}

insideVolume([13.1, 50, 31.5, 50, 80, 50, -5, 18, 43])