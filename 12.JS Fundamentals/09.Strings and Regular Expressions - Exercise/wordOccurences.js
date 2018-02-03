function wordOccurences(text, searchedItem) {
    searchedItem = '\\b' + searchedItem + '\\b'
    let pattern = RegExp(searchedItem, 'gi')
    let match = text.match(pattern)

    if (match) {
        console.log(match.length)
    }
    else {
        console.log(0)
    }
}

wordOccurences('How do you plan on achieving that? ' +
    'How? How can you even think of that?',
    'how')