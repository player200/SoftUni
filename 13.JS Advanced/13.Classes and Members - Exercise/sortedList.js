class SortedList {
    constructor() {
        this.collector = []
        this.size = 0
    }

    add(item) {
        this.collector.push(item)
        this.collector.sort((a, b) => a - b)
        this.size++
    }

    remove(index) {
        if (this.size === 0) {
            throw new Error('List is empty!')
        }

        if (index < 0 || index > this.collector.length - 1) {
            throw new RangeError('Index out of Range!')
        }

        this.collector.splice(index, 1)
        this.size--
    }

    get(index) {
        if (this.size === 0) {
            throw new Error('List is empty!')
        }

        if (index < 0 || index > this.collector.length - 1) {
            throw new RangeError('Index out of Range!')
        }

        return this.collector[index]
    }
}