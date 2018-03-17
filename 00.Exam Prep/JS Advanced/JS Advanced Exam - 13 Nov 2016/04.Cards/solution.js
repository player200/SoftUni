function cardDeckBuilder(selector) {
    return{
        addCard(face,suit) {
            if(suit==='H'){
                suit='\u2665'
            }
            else if(suit==='C'){
                suit='\u2663'
            }
            else  if(suit==='D'){
                suit='\u2666'
            }
            else if(suit==='S'){
                suit='\u2660'
            }
            let card=($(`<div class="card">${face}${suit}</div>`))
                .click(function () {
                    let cards=$('.card')
                    $(selector).append(cards.get().reverse())
                })
            $(selector).append(card)
        }
    }
}