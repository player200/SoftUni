function subSum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr)) {
        return NaN
    }

    startIndex = startIndex < 0 ? 0 : startIndex
    endIndex = endIndex >= arr.length ? arr.length-1 : endIndex

    let sum = 0
    for (let i = startIndex; i <= endIndex; i++) {
        sum = sum + Number(arr[i])
    }

    return sum
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300))
console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1))
console.log(subSum([10, 'twenty', 30, 40], 0, 2))
console.log(subSum([], 1, 2))
console.log(subSum('text', 0, 2))