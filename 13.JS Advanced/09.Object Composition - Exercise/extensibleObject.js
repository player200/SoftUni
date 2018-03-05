function extensibleObject() {
    let obj = {
        __proto__: {},
        extend: function (params) {
            for (let key in params) {
                if (params.hasOwnProperty(key)) {
                    let element = params[key]
                    if (typeof  element === 'function') {
                        Object.getPrototypeOf(obj)[key] = element
                    } else {
                        obj[key] = element
                    }
                }
            }
        }
    }

    return obj
}