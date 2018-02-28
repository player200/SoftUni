let vector = (() => {
    function add(firstArr, secondArr) {
        let [xa, xb] = firstArr
        let [ya, yb] = secondArr
        let result = []
        result.push(Number(xa) + Number(ya))
        result.push(Number(xb) + Number(yb))
        return result
    }

    function multiply(arr, multiplayer) {
        let [xa, xb] = arr
        let result = []
        result.push(xa * multiplayer)
        result.push(xb * multiplayer)
        return result
    }

    function length(arr) {
        let firstParam = arr[0]
        let secondParam = arr[1]
        let result = Math.sqrt(firstParam * firstParam + secondParam * secondParam)
        return result
    }

    function dot(firstArr, secondArr) {
        let [xa, xb] = firstArr
        let [ya, yb] = secondArr
        let result = xa * ya + xb * yb
        return result
    }

    function cross(firstArr, secondArr) {
        let [xa, xb] = firstArr
        let [ya, yb] = secondArr
        let result = xa * yb - xb * ya
        return result
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})()

console.log(vector.dot([2, 3], [2, -1]))