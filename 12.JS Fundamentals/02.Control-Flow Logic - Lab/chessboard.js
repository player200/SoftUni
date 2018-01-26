function chessboard(number) {
    console.log(`<div class="chessboard">`)
    for (let i = 0; i < number; i++) {
        console.log(` <div>`)
        let color = (i % 2 == 0) ? 'black' : 'white'
        for (let j = 0; j < number; j++) {
            console.log(`  <span class="${color}"></span>`)
            color = color == 'white' ? 'black' : 'white'
        }
        console.log(` </div>`)
    }
    console.log(`</div>`)
}

chessboard(3)