class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString
        this.innerLength = Number(innerLength)
    }

    decrease(count) {
        this.innerLength -= count
        if (this.innerLength < 0) {
            this.innerLength = 0
        }
    }

    increase(count) {
        this.innerLength += count
    }

    toString() {
        if (this.innerString.length > this.innerLength) {
            return this.innerString.substr(0, this.innerLength) + '...'
        }

        return this.innerString.substr(0, this.innerLength)
    }
}

let test = new Stringer("Test", 5)
console.log(test.toString())
test.decrease(3)
console.log(test.toString())
test.decrease(5)
console.log(test.toString())
test.increase(4)
console.log(test.toString())
