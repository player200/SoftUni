function tripLength(params) {
    let [x1, y1, x2, y2, x3, y3] = params

    function distance(a1, b1, a2, b2) {
        return Math.sqrt(Math.pow((a1 - a2), 2) + Math.pow((b1 - b2), 2))
    }

    let oneTwo = distance(x1, y1, x2, y2);
    let twoThree = distance(x2, y2, x3, y3);
    let oneThree = distance(x3, y3, x1, y1);

    let twoShortest = [oneTwo, twoThree, oneThree];

    twoShortest = twoShortest.sort((a, b) => a - b);
    twoShortest.pop();
    let sum = twoShortest.reduce((a, b) => a + b);

    if (oneTwo <= oneThree && oneThree >= twoThree) {
        console.log(`1->2->3: ${sum}`)
    }
    else if (oneTwo <= twoThree && oneThree < twoThree)
        console.log(`2->1->3: ${sum}`)
    else{
        console.log(`1->3->2: ${sum}`)
    }
}

tripLength([0, 0, 2, 0, 4, 0])