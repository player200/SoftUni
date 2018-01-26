function validityChecker(numbers) {
    let [x1, y1, x2, y2] = numbers

    console.log(`{${x1}, ${y1}} to {0, 0} is ${distance(x1, y1, 0, 0)}`)
    console.log(`{${x2}, ${y2}} to {0, 0} is ${distance(x2, y2, 0, 0)}`)
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${distance(x1, y1, x2, y2)}`)

    function distance(x1, y1, x2, y2) {
        let distance = Math.sqrt(Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2))

        if (distance % 1 === 0) {
            return "valid"
        }

        return "invalid"
    }
}

validityChecker([3, 0, 0, 4])