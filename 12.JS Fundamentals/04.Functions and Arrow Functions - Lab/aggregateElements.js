function aggregateElements(params) {
    let sum = 0
    let sumInLess = 0
    let concat = ''
    for (let item of params) {
        sum += item
        sumInLess = sumInLess + 1 / item
        concat = concat + item.toString()
    }
    console.log(sum)
    console.log(sumInLess)
    console.log(concat)
}

aggregateElements([1, 2, 3])