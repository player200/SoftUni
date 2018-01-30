function printArrayWithGivenDelimiter(arr) {
    let splitter = arr.pop()
    console.log(arr.join(`${splitter}`))
}

printArrayWithGivenDelimiter([
    'One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-'])