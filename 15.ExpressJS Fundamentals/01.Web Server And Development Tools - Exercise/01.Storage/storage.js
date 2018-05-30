const fs = require('fs')
const filePath = './storage.json'

let store = {}

module.exports = {
    put: (key, value) => {
        if (typeof key !== 'string') {
            throw new Error('The key need to be string!')
        }
        if (store.hasOwnProperty(key)) {
            throw new Error('The key is awredy used!')
        }

        store[key] = value
    },
    get: (key) => {
        if (typeof key !== 'string') {
            throw new Error('The key need to be string!')
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('There is no such key!')
        }

        return store[key]
    },
    getAll: () => {
        if (Object.keys(store).length === 0) {
            return 'There are no items in the storage'
        }

        return JSON.stringify(store)
    },
    update: (key, newValue) => {
        if (typeof key !== 'string') {
            throw new Error('The key need to be string!')
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('There is no such key!')
        }

        store[key] = newValue
    },
    delete: (key) => {
        if (typeof key !== 'string') {
            throw new Error('The key need to be string!')
        }
        if (!store.hasOwnProperty(key)) {
            throw new Error('There is no such key!')
        }

        delete store[key]
    },
    clear: () => {
        store = {}
    },
    save: () => {
        fs.writeFileSync(filePath, JSON.stringify(store))
    },
    load: () => {
        let data = fs.readFileSync(filePath, "utf8")
        store = JSON.parse(data)
    },
    loadAsync: () => {
        return new Promise((resolve, reject) => {
            fs.readFile(filePath, (err, data) => {
                if (err) {
                    throw err
                }

                store = JSON.parse(data)
                resolve()
            })
        })
    }
}