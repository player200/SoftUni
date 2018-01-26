function wordsUppercase(stringy) {
    let strUpper = stringy.toUpperCase()
    let words = extractWords()
    words = words.filter(w => w != '')

    return words.join(', ')

    function extractWords() {
        return strUpper.split(/\W+/)
    }
}
console.log(wordsUppercase('Hi, how are you?'))
