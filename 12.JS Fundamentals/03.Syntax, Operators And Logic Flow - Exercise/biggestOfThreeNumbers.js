function biggestOfThreeNumbers(numbers) {
    console.log(Math.max.apply(null, numbers))
}

biggestOfThreeNumbers([5, -2, 7])