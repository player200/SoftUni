function rotateArray(arr) {
    let rotationCounter = arr.pop()

    for (let i = 0; i < rotationCounter % arr.length; i++) {
        arr.unshift(arr.pop())
    }

    console.log(arr.join(' '))
}

rotateArray([
    'Banana',
    'Orange',
    'Coconut',
    'Apple',
    15])