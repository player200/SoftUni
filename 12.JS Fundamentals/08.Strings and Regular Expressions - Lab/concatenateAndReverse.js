function concatenateAndReverse(arr) {
    let result=''
    for (let i = 0; i < arr.length; i++) {
        result=result+arr[i]
    }
    console.log(result.split('').reverse().join(''))
}

concatenateAndReverse(['I', 'am', 'student'])