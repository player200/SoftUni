function sortArray(arr) {
    console.log(arr
        .sort()
        .sort((a, b) => a.length - b.length)
        .join('\n'))
}

sortArray([
    'test',
    'Deny',
    'omen',
    'Default'])