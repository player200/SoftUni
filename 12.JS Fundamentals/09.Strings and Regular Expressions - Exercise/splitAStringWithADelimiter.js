function splitAStringWithADelimiter(text, spliter) {
    let output = text.split(spliter)
    console.log(output.join('\n'))
}

splitAStringWithADelimiter('One-Two-Three-Four-Five', '-')
