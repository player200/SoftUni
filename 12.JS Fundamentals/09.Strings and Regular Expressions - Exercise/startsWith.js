function startsWith(text, searchedItem) {
    let indexOfItem=text.indexOf(searchedItem)
    if(indexOfItem===0){
        console.log('true')
    }
    else {
        console.log('false')
    }
}

startsWith('How have you been?','how')