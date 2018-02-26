function increment(selector) {
    let containor = $(selector)
    let fragment=document.createDocumentFragment()
    let textArea=$('<textarea>')
    let incrementButton = $('<button>Increment</button>')
    let addButton = $('<button>Add</button>')
    let list=$('<ul>')

    textArea.val(0)
    textArea.addClass('counter')
    textArea.attr('disabled','true')

    incrementButton.addClass('btn')
    incrementButton.attr('id','incrementBtn')

    addButton.addClass('btn')
    addButton.attr('id','addBtn')

    list.addClass('results')

    $(incrementButton).on('click',function () {
        textArea.val(+textArea.val()+1)
    })
    $(addButton).on('click',function () {
        let currentValue=textArea.val()
        let li=$(`<li>${currentValue}</li>`)
        li.appendTo(list)
    })

    textArea.appendTo(fragment)
    incrementButton.appendTo(fragment)
    addButton.appendTo(fragment)
    list.appendTo(fragment)

    containor.append(fragment)
}