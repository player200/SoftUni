function primeNumberChecker(number) {
    let prime = true;

    for (let d = 2; d <= Math.sqrt(number); d++) {
        if (number % d == 0) {
            prime = false;
            break;
        }
    }
    return prime && (number > 1);
}

console.log(primeNumberChecker(1))