function aggregateTable(arr) {
    let incomes = 0
    let result = []
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i]
            .split('|')
            .filter(a=>a!=='')
        result.push(tokens[0].trim())
        incomes += Number(tokens[1])
    }

    console.log(result.join(', '))
    console.log(incomes)
}

aggregateTable(['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
)