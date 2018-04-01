function attachEvents() {
    let baseUrl = 'https://judgetests.firebaseio.com/'
    let symbols = {
        Sunny: "\u2600",
        'Partly sunny': "\u26C5",
        Overcast: "\u2601",
        Rain: "\u2602",
        Degrees: "\u00B0"
    }

    let current = $('#current')
    let upcoming = $('#upcoming')

    $('#submit').on('click', function () {
        let code = undefined
        let location = $('#location').val()

        $.get(baseUrl + 'locations/.json')
            .then(function (data) {
                for (let loc of data) {
                    if (loc.name === location) {
                        code = loc.code
                        break
                    }
                }

                if (typeof code === 'undefined') {
                    error()
                    return
                }

                $.get(baseUrl + `forecast/today/${code}.json`)
                    .then(todayWeather)
                    .catch(error)

                $.get(baseUrl + `forecast/upcoming/${code}.json`)
                    .then(displayForecast)
                    .catch(error)
            })
            .catch(error)
    })

    function todayWeather(data) {
        $('#forecast')
            .css('display', 'block')
        current.empty()

        current
            .append($('<div class="label">Current conditions</div>'))
        current
            .append($(`<span class="condition symbol">${symbols[data.forecast.condition]}</span>`))

        let container = $('<span class="condition">')

        container
            .append($(`<span class="forecast-data">${data.name}</span>`))
        container
            .append($(`<span class="forecast-data">${data.forecast.low}${symbols.Degrees}/${data.forecast.high}${symbols.Degrees}</span>`))
        container
            .append($(`<span class="forecast-data">${data.forecast.condition}</span>`))

        current
            .append(container)
    }

    function displayForecast(data) {
        $('#forecast')
            .css('display', 'block')
        upcoming.empty()
        upcoming
            .append($('<div class="label">Three-day forecast</div>'))

        for (let fore of data.forecast) {
            let spanContainer = $('<span class="upcoming">')

            spanContainer
                .append($(`<span class="symbol">${symbols[fore.condition]}</span>`))
            spanContainer
                .append($(`<span class="forecast-data">${fore.low}${symbols.Degrees}/${fore.high}${symbols.Degrees}</span>`))
            spanContainer
                .append($(`<span class="forecast-data">${fore.condition}</span>`))

            upcoming
                .append(spanContainer)
        }
    }

    function error() {
        $('#forecast')
            .text('Error')
            .css('display', 'block')
    }
}

attachEvents()

//To test use those values: "London", "New York", "Barcelona"