function solve() {
    let infoDiv = $('#info')
        .find('span')
    let departs = $('#depart')
    let arrives = $('#arrive')
    let baseUrl = 'https://judgetests.firebaseio.com/schedule/'
    let nextStopId = 'depot'

    function depart() {
        departs.prop('disabled', true)
        arrives.prop('disabled', false)
        request()
    }

    function arrive() {
        departs.prop('disabled', false)
        arrives.prop('disabled', true)
        request()
    }

    function request() {
        let url = baseUrl + nextStopId + '.json'
        console.log(url)
        $.get(url)
            .then(function (res) {
                let busStopName = res.name
                if (departs.prop('disabled') === true) {
                    infoDiv.text(`Next stop ${busStopName}`)
                }
                else {
                    nextStopId = res.next
                    infoDiv.text(`Arriving at ${busStopName}`)
                }
            })
            .catch(function () {
                infoDiv.text('Error')
                departs.prop('disabled', true)
                arrives.prop('disabled', true)
            })
    }

    return {
        depart,
        arrive
    }
}

let result = solve()