function triangleArea(sideA, sideB, sideC) {
    let semiPirameter = (sideA + sideB + sideC) / 2
    let result = Math.sqrt(semiPirameter*(semiPirameter - sideA)*(semiPirameter - sideB)*(semiPirameter - sideC))
    console.log(result)
}

triangleArea(2, 3.5, 4)