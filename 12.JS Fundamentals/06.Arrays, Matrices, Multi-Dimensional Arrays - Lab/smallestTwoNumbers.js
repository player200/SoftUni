function smallestTwoNumbers(numbers) {
    let result=numbers
        .sort((a,b)=>a-b)

    return console.log(result.slice(0,2).join(' '))
}

smallestTwoNumbers([30, 15, 50, 5])