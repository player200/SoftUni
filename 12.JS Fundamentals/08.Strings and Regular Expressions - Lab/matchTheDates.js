function matchTheDates(arr) {
    let regex=/\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g
    while(tokens=regex.exec(arr)){
        console.log(`${tokens[0]} (Day: ${tokens[1]}, Month: ${tokens[2]}, Year: ${tokens[3]})`)
    }
}

matchTheDates(['I am born on 30-Dec-1994.',
    'This is not date: 512-Jan-1996.',
    'My father is born on the 29-Jul-1955.'
])