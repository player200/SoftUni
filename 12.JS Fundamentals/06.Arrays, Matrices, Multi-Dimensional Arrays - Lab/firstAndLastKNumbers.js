function firstAndLastKNumbers(params) {
    let k = params.shift()

    console.log(params.slice(0, k, params).join(' '))
    console.log(params.slice(params.length - k, params.length, params).join(' '))
}

firstAndLastKNumbers([2, 7, 8, 9])