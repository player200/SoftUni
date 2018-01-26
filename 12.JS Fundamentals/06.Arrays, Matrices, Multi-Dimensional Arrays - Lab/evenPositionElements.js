function evenPositionElements(params) {
    let result=[]
    for (let indicator in params) {
        if(indicator%2===0){
            result.push(params[indicator])
        }
    }
    return result.join(' ')
}

console.log(evenPositionElements(['20', '30', '40']))