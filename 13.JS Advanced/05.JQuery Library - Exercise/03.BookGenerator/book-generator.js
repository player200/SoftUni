let createBook
createBook =(function bookGenerator() {
    let id = 1
    return function createBook(conteiner, title, author, ISBN) {
        let currentContainor=$(conteiner)
        let div=$(`<div>`)
        let parTitle=$(`<p>${title}</p>`)
        let parAuthor=$(`<p>${author}</p>`)
        let parIsbn=$(`<p>${ISBN}</p>`)
        let btnSelect=$('<button>Select</button>')
        let btnDeselect=$('<button>Deselect</button>')

        parTitle.addClass('title')
        parAuthor.addClass('author')
        parIsbn.addClass('isbn')

        div.addClass(`book${id}`)
        div.css('border','none')

        $(btnSelect).on('click', function () {
            div.css('border', '2px solid blue');
        })
        $(btnDeselect).on('click', function () {
            div.css('border', 'none');
        })

        parTitle.appendTo(div)
        parAuthor.appendTo(div)
        parIsbn.appendTo(div)
        btnSelect.appendTo(div)
        btnDeselect.appendTo(div)
        currentContainor.append(div)

        id++
    }
}())