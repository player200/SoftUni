function move(command) {
    let availableItems = $('#available-towns')
    let selectedItems = $('#selected-towns')
    let printer = $('#output')

    if (command === 'right') {
        let itemToAdd = availableItems
            .find('option:selected')

        selectedItems
            .append(itemToAdd)
    }
    else if (command === 'left') {
        let itemToAdd = selectedItems
            .find('option:selected')

        availableItems
            .append(itemToAdd)
    }
    else if (command === 'print') {
        let itemsToPrint = selectedItems
            .find('option')
            .toArray()
            .map(el => el.textContent)
            .join('; ')

        printer.append(itemsToPrint)
    }
}