function countWordsInAText(text) {
    let arr = text.join('\n');
    let words = arr
        .split(/[^a-zA-Z0-9_]/)
        .filter(w => w !== '')
    let objCollector = {}
    for (let i = 0; i < words.length; i++) {
        let currentWord = words[i]
        if (objCollector.hasOwnProperty(currentWord)) {
            objCollector[currentWord]++
        }
        else {
            objCollector[currentWord] = 1
        }
    }

    console.log(JSON.stringify(objCollector))
}

countWordsInAText(['Far too slow, you\'re far too slow.'])