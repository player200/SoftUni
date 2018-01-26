function sumAndVAT(numbers) {
    let sum = 0
    for (let i = 0; i < numbers.length; i++) {
        sum += numbers[i]
    }
    let vat = sum * 0.2

    console.log(sum)
    console.log(vat)
    console.log(sum + vat)
}

sumAndVAT([1.20, 2.60, 3.50])