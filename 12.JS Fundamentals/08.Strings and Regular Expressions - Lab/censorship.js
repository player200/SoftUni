function censorship(text, stringsForRemove) {
    for (let i = 0; i < stringsForRemove.length; i++) {
        let stringToken = stringsForRemove[i]
        let index = text.indexOf(stringToken)
        let replacebleItem = '-'.repeat(stringsForRemove[i].length)

        while (index > -1) {
            text = text.replace(stringToken, replacebleItem)
            index = text.indexOf(stringToken, index + 1)
        }
    }

    console.log(text)
}

censorship('roses are red, violets are blue', [', violets are', 'red'])