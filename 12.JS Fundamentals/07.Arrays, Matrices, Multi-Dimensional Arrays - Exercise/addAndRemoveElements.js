function addAndRemoveElements(arr) {
    let result=[]
    let counter=1
    for (let i = 0; i < arr.length; i++) {
        if(arr[i]==='add'){
            result.push(counter)
        }
        if(arr[i]==='remove'){
            result.pop()
        }

        counter++
    }

    if(result.length!==0){
        console.log(result.join('\n'))
    }
    else {
        console.log('Empty')
    }
}

addAndRemoveElements([
    'add',
    'add',
    'remove',
    'add',
    'add'])