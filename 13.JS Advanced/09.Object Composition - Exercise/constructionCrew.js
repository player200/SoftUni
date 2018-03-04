function constructionCrew(paramsObj) {
    if (paramsObj['handsShaking'] === false) {
        return paramsObj
    }
    else {
        let currentAlcohol = paramsObj['bloodAlcoholLevel']
        let needToDrink = (paramsObj['weight'] * 0.1) * paramsObj['experience']
        paramsObj['bloodAlcoholLevel']=currentAlcohol+needToDrink
        paramsObj['handsShaking']=false
        return paramsObj
    }
}

console.log(constructionCrew({
    weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true
}));
