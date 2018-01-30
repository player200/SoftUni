function printEveryNthElementFromAnArray(arr) {
    let steps = arr.pop()
    for (let i = 0; i < arr.length; i++) {
        if (i % steps === 0) {
            console.log(arr[i])
        }
    }
}

printEveryNthElementFromAnArray([
    5,
    20,
    31,
    4,
    20,
    2])