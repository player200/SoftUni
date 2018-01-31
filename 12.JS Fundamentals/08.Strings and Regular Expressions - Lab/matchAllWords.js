function matchAllWords(text) {
    let regex=/\w+/g
    text = text.match(regex)
    console.log(text.join('|'))
}

matchAllWords('A Regular Expression needs to have ' +
    'the global flag in order to match all occurrences in the text')