function subtract() {
    let firstNumber = document.getElementById('firstNumber')
    let secondNumber = document.getElementById('secondNumber')
    document.getElementById('result').textContent = Number(firstNumber.value) - Number(secondNumber.value)
}