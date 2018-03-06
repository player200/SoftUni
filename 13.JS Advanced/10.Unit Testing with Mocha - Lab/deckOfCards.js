function deckOfCards(arr) {
    const VALID_FACES = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
    const VALID_SUITS = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    }

    let collector = []
    try {
        for (let item of arr) {
            let face = item.length === 3 ? item[0] + item[1] : item[0]
            let suit = item.length === 3 ? item[2] : item[1]

            if (!VALID_FACES.includes(face)) {
                throw new Error(`Invalid card: ${face}${suit}`)
            }
            if (!VALID_SUITS.hasOwnProperty(suit)) {
                throw new Error(`Invalid card: ${face}${suit}`)
            }

            let card = {
                face: face,
                suit: suit,
                toString: () => {
                   return card.face + VALID_SUITS[card.suit]
                }
            }
            collector.push('' + card)
        }
    }
    catch (er) {
        console.log(er.message)
        return
    }

    console.log(collector)
}

deckOfCards(['AS', '10D', 'KH', '2C'])
deckOfCards(['5S', '3D', 'QD', '1C'])