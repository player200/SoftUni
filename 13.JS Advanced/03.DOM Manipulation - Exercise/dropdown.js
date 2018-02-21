function addItem() {
    let text = document.getElementById('newItemText')
    let value = document.getElementById('newItemValue')
    let selecter = document.getElementById('menu')
    let option = document.createElement('option')
    option.textContent = text.value
    option.value = value.value
    selecter.appendChild(option)
    text.value=''
    value.value=''
}