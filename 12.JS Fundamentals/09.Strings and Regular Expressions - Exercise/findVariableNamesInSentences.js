function findVariableNamesInSentences(text) {
    let pattern=/\b_{1}[a-zA-Z0-9]+\b/g
    let match=text.match(pattern)
    let output=[]
    for (let name of match) {
        output.push(name.replace('_',''))
    }
    console.log(output.join(','))
}

findVariableNamesInSentences('__invalidVariable _evenMoreInvalidVariable_ _validVariable')