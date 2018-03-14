(() => {
    let id = 0

    class Extensible {
        constructor() {
            this.id = id++
        }

        extend(item) {
            for (let property in item) {
                if (item.hasOwnProperty(property)) {
                    let element = item[property]
                    if (typeof  element === 'function') {
                        Extensible.prototype[property] = element
                    } else {
                        this[property] = element
                    }
                }
            }
        }
    }

    return Extensible
})()