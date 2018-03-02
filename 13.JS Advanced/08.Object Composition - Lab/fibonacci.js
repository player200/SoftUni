function fibonacci(){
    let previousNumber = 0
    let currentNumber = 0
    let result = 0
    function getNext() {
        if (currentNumber === 0) {
            currentNumber = 1
            result = currentNumber
            return result
        }
        result = previousNumber + currentNumber
        previousNumber = currentNumber
        currentNumber = result

        return result
    }

    return getNext
}

let fib = fibonacci()
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13