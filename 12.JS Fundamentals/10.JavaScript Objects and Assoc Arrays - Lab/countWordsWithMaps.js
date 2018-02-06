function countWordsWithMaps(arr) {
    let text = arr.join('\n')
    let words = text
        .split(/[^a-zA-Z0-9_]/)
        .filter(w => w !== '')
    let myMap = new Map()
    for (let i = 0; i < words.length; i++) {
        let currentWord=words[i].toLowerCase()
        if(myMap.has(currentWord)){
            myMap.set(currentWord,myMap.get(currentWord)+1)
        }
        else {
            myMap.set(currentWord,1)
        }
    }

    let sortedKeys = Array.from(myMap.keys()).sort()
    for (let key of sortedKeys) {
        console.log(`'${key}' -> ${myMap.get(key)} times`)
    }
}

countWordsWithMaps(['Far too slow, you\'re far too slow.'])