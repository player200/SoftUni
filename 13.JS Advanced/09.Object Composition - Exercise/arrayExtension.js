(function arrayExtension() {
    Array.prototype.last = function () {
        return this[this.length - 1]
    }

    Array.prototype.skip = function (count) {
        let result = []
        for (let i = count; i < this.length; i++) {
            result.push(this[i])
        }
        return result
    }

    Array.prototype.take = function (count) {
        let result = []
        for (let i = 0; i < count; i++) {
            result.push(this[i])
        }
        return result
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b)
    }

    Array.prototype.average = function () {
        let count = this.length
        return this.reduce((a, b) => a + b) / count
    }
})()