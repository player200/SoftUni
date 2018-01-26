function cookingByNumbers(params) {
    let startingPoint = Number(params[0])

    for (let i = 1; i < 6; i++) {
        switch (params[i]) {
            case'chop':
                console.log(chop(startingPoint))
                break
            case'dice':
                console.log(dice(startingPoint))
                break
            case'spice':
                console.log(spice(startingPoint))
                break
            case'bake':
                console.log(bake(startingPoint))
                break
            case'fillet':
                console.log(fillet(startingPoint))
                break
        }
    }

    function chop(number) {
        startingPoint = number / 2
        return startingPoint
    }

    function dice(number) {
        startingPoint = Math.sqrt(number)
        return startingPoint
    }

    function spice(number) {
        startingPoint=number+1
        return startingPoint
    }

    function bake(number) {
        startingPoint=number * 3
        return startingPoint
    }

    function fillet(number) {
        startingPoint=number - (number * 0.2)
        return startingPoint
    }
}

cookingByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet'])