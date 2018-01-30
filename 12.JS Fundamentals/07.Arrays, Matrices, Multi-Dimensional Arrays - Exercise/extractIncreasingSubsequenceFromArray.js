function extractIncreasingSubsequenceFromArray(arr) {
    let currentBiggestItem = Number.NEGATIVE_INFINITY
    let result = []
    for (let i = 0; i < arr.length; i++) {
        if (currentBiggestItem <= arr[i]) {
            currentBiggestItem = arr[i]
            result.push(currentBiggestItem)
        }
    }
    console.log(result.join('\n'))
}

extractIncreasingSubsequenceFromArray([
    1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24])