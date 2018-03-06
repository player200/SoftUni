function playingCards(face, suit) {
    const VALID_FACES = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
    const VALID_SUITS = {
        'S': '\u2660',
        'H': '\u2665 ',
        'D': '\u2666',
        'C': '\u2663'
    }

    if (!VALID_FACES.includes(face)) {
        throw new Error(`Invalid card: ${face}`)
    }
    if (!VALID_SUITS.hasOwnProperty(suit)) {
        throw new Error(`Invalid card: ${suit}`)
    }

    let card = {
        face: face,
        suit: suit,
        toString: () => {
            return card.face + VALID_SUITS[card.suit]
        }
    }

    return card
}

console.log('' + playingCards('A', 'S'))
console.log('' + playingCards('10', 'H'))
console.log('' + playingCards('1', 'C'))