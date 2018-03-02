$(function () {
    let model = getModel()
    model.init('#num1', '#num2', '#result')
    $('#sumButton').on('click', model.add)
    $('#subtractButton').on('click', model.subtract)

    function getModel() {
        let firstNumber
        let secondNumber
        let result

        function init(selector1, selector2, resultSelector) {
            firstNumber = $(selector1)
            secondNumber = $(selector2)
            result = $(resultSelector)
        }

        function add() {
            result.val(Number(firstNumber.val()) + Number(secondNumber.val()))
        }

        function subtract() {
            result.val(Number(firstNumber.val()) - Number(secondNumber.val()))
        }

        return {
            init,
            add,
            subtract
        }
    }
})