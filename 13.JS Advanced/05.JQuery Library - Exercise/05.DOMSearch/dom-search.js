function domSearch(selector, sensetivityOfSearchText) {
    let conteiner = $(selector)
    let addDiv=$('<div>')
    let searchDiv=$('<div>')
    let resultDiv=$('<div>')

    conteiner.addClass('items-control')
    addDiv.addClass('add-controls')
    searchDiv.addClass('search-controls')
    resultDiv.addClass('result-controls')

    let addLabel=$('<label>Enter text: </label>')
    let addInput=$('<input id="addInput">')
    addLabel.append(addInput)
    let addLink = $('<a>')
    addLink.attr('href', '#')
    addLink.attr('id', 'add')
    addLink.addClass('button')
    addLink.css('display', 'inline-block')
    addLink.text('Add')

    let searchLabel = $('<label>Search: </label>')
    let searchInput = $('<input>')
    searchInput.attr('id', 'searchInput')
    searchInput.on('input', function () {
        let text = $(this).val()
        $('.list-item').each((i, li) => searchesMatched(li, text))
    })

    let itemsList = $('<ul>')
    itemsList.addClass('items-list')

    addDiv.append(addLabel)
    addDiv.append(addLink)
    searchLabel.append(searchInput)
    searchDiv.append(searchLabel)
    resultDiv.append(itemsList)
    conteiner.append(addDiv)
    conteiner.append(searchDiv)
    conteiner.append(resultDiv)

    $('#add').on('click', function (event) {
        event.preventDefault()
        let li = $('<li>')
        let link = $('<a>')
        link.attr('href', '#')
        link.addClass('button')
        link.text('X')
        link.on('click', function (event) {
            event.preventDefault()
            $(this).parent().remove()
        });
        let text = $('<strong>')
        let inputVal=$('#addInput').val()
        text.text(`${inputVal}`)

        li.addClass('list-item')
        li.append(link)
        li.append(text)
        $('.items-list').append(li)
    })

    function searchesMatched(li, text) {
        $(li).css('display', 'block')
        if(sensetivityOfSearchText) {
            let regex = new RegExp(''+text+'', '')
            if (!regex.test($(li).find('strong').text())) {
                $(li).css('display', 'none')
            }
        } else {
            let regex = new RegExp(''+text+'', 'i')
            if (!regex.test($(li).find('strong').text())) {
                $(li).css('display', 'none')
            }
        }
    }
}