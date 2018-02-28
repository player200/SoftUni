(function functionalSum() {
    let currentValue=0
    return function sum(num) {
        currentValue += num
        sum.toString = () => currentValue
        return sum
    }
}())