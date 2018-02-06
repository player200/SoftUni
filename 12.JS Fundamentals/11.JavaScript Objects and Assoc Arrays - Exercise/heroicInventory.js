function heroicInventory(arr) {
    let data = []
    for (let i = 0; i < arr.length; i++) {
        let heroTokens = arr[i]
            .split(' / ')
            .filter(d => d !== '')
        let heroName = heroTokens[0]
        let heroLevel = Number(heroTokens[1])
        let heroItems = []
        if (heroTokens.length > 2) {
            heroItems = heroTokens[2]
                .split(', ')
                .filter(it => it !== '')
        }
        let hero = {
            name: heroName,
            level: heroLevel,
            items: heroItems
        }
        data.push(hero)
    }
    console.log(JSON.stringify(data))
}

heroicInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
])