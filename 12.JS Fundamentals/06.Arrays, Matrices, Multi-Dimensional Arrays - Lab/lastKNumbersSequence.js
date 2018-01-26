function lastKNumbersSequence(number, k) {
    let seq = [1]

    for (let current = 1; current < number; current++) {
        seq[current] = seq.slice((Math.max(current - k,0))).reduce((a,b)=>a+b)
    }

    console.log(seq.join(' '))
}

lastKNumbersSequence(6, 3)