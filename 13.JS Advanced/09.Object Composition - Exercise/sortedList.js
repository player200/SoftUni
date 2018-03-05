function sortedList() {
    let collector = []

    return {
        add: function(item)  {
            collector.push(item)
            collector.sort((a, b) => a - b)
            this.size++
        },
        remove: function(index) {
            if (this.size === 0) {
                throw new Error('List is empty!')
            }

            if (index < 0 || index > collector.length - 1) {
                throw new RangeError('Index out of Range!')
            }

            collector.splice(index, 1)
            this.size--
        },
        get: function(index)  {
            if (this.size === 0) {
                throw new Error('List is empty!')
            }

            if (index < 0 || index > collector.length - 1) {
                throw new RangeError('Index out of Range!')
            }

            return collector[index]
        },
        size: 0
    }
}

let list = sortedList()
list.add(5)
console.log(list.get(0));
list.add(3)
console.log(list.get(0));
list.remove(0)
console.log(list.get(0));
console.log(list.size);

