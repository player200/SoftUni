function endsWith(text,endSubst) {
    let lenthOfEndSubst=endSubst.length
    let lenthOfText=text.length
    let searchedItem=text.substr(lenthOfText-lenthOfEndSubst)
    if(searchedItem===endSubst){
        console.log('true')
    }
    else {
        console.log('false')
    }
}

endsWith('This sentence ends with fun?','fun?')