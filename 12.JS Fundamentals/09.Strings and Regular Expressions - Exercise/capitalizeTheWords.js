function capitalizeTheWords(text) {
    let words = text.split(' ')
    let outputCollector = []
    for (let i = 0; i < words.length; i++) {
        let currentWord = words[i]
        let firstLetter = currentWord[0].toUpperCase()
        let otherLetters = currentWord.substr(1).toLowerCase()
        outputCollector.push(firstLetter.concat(otherLetters))
    }
    console.log(outputCollector.join(' '))
}

capitalizeTheWords('Was that Easy? tRY thIs onE for SiZe!')