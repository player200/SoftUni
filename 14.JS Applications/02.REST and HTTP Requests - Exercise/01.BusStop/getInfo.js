function getInfo() {
    let number = Number($('#stopId').val())
    if (number === ''
        || isNaN(number)) {
        $('#buses').empty()
        $('#stopName').empty()
        $('#stopName').append('Error')
        $('#stopId').val('')
        return
    }

    let url = `https://judgetests.firebaseio.com/businfo/${number}.json`
    $.get(url)
        .then(function (buses) {
            $('#buses').empty()
            $('#stopName').empty()
            $('#stopName').append(buses.name)
            for (let key in buses.buses) {
                $('#buses').append($(`<li>Bus ${key} arrives in ${buses.buses[key]}</li>`))
            }
        })
        .catch(function (err) {
            $('#buses').empty()
            $('#stopName').empty()
            $('#stopName').append('Error')
        })
    $('#stopId').val('')
    //valid bus numbers 1287, 1308, 1327, 2334
}