function expressionSplit(text) {
    let regex=/[\s;,\\\.()]+/g
    text=text.split(regex).forEach(arr=>console.log(arr))
}

expressionSplit('let sum = 4 * 4,b = "wow";')