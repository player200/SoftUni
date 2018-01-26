function assignProperties(params) {
    let firstProp = params[0]
    let secondProp = params[2]
    let thirdProp = params[4]
    let firstValue = params[1]
    let secondValue = params[3]
    let thirdValue = params[5]
    let obj = {}

    obj[firstProp] = firstValue
    obj[secondProp] = secondValue
    obj[thirdProp] = thirdValue

    console.log(obj)
}

assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male'])