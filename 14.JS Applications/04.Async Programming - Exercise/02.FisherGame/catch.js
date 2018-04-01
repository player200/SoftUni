function attachEvents() {
    //set your appKey of kenvey data, create user
    let appKey = ''
    let user = ''
    let password = ''
    let authHeaders = 'Basic ' + btoa(user + ':' + password)
    let baseUrl = `https://baas.kinvey.com/appdata/${appKey}/biggestCatches`

    $('.load').on('click', load)

    $('.add').on('click', add)

    function add() {
        let angler = $('#addForm .angler').val()
        let weight = $('#addForm .weight').val()
        let species = $('#addForm .species').val()
        let location = $('#addForm .location').val()
        let bait = $('#addForm .bait').val()
        let captureTime = $('#addForm .captureTime').val()

        let newObj = {
            angler: angler,
            weight: Number(weight),
            species: species,
            location: location,
            bait: bait,
            captureTime: Number(captureTime)
        }

        $.ajax({
            method: 'POST',
            url: baseUrl,
            data: JSON.stringify(newObj),
            headers: {
                'Content-type': 'application/json',
                'Authorization': authHeaders
            },
            success: load
        })
    }

    function load() {
        $.ajax({
            method: 'GET',
            url: baseUrl,
            headers: {
                'Content-type': 'application/json',
                'Authorization': authHeaders
            }
        })
            .then(function (data) {
                $('#main').empty()
                $('#main')
                    .append($('<legend>Catches</legend>'))

                let outerContainer = $('<div id="catches">')
                for (let currentData of data) {
                    let divContainer =$(`<div class="catch" data-id="${currentData._id}">`)
                            .append($(`<label>Angler</label>`))
                            .append($(`<input type="text" class="angler" value="${currentData.angler}"/>`))
                            .append($(`<label>Weight</label>`))
                            .append($(`<input type="number" class="weight" value="${currentData.weight}"/>`))
                            .append($(`<label>Species</label>`))
                            .append($(`<input type="text" class="species" value="${currentData.species}"/>`))
                            .append($(`<label>Location</label>`))
                            .append($(`<input type="text" class="location" value="${currentData.location}"/>`))
                            .append($(`<label>Bait</label>`))
                            .append($(`<input type="text" class="bait" value="${currentData.bait}"/>`))
                            .append($(`<label>Capture Time</label>`))
                            .append($(`<input type="number" class="captureTime" value="${currentData.captureTime}"/>`))
                            .append($(`<button class="update">Update</button>`)
                                .on('click', updateCatch))
                            .append($(`<button class="delete">Delete</button>`)
                                .on('click', deleteCatch.bind(currentData)))

                    outerContainer
                        .append(divContainer)

                    function updateCatch() {
                        let currentContainer = $(this)
                            .closest($('div'))

                        let newObj = {
                            angler: currentContainer
                                .find($('.angler'))
                                .val(),
                            weight: Number(currentContainer
                                .find($('.weight'))
                                .val()),
                            species: currentContainer
                                .find($('.species'))
                                .val(),
                            location: currentContainer
                                .find($('.location'))
                                .val(),
                            bait: currentContainer
                                .find($('.bait'))
                                .val(),
                            captureTime: Number(currentContainer
                                .find($('.captureTime'))
                                .val())
                        }

                        $.ajax({
                            method: 'PUT',
                            url: baseUrl + `/${currentContainer
                                .attr("data-id")}`,
                            data: JSON.stringify(newObj),
                            headers: {
                                'Content-type': 'application/json',
                                'Authorization': authHeaders
                            },
                            success: load
                        })
                    }

                    function deleteCatch() {
                        $.ajax({
                            method: 'DELETE',
                            url: baseUrl + `/${this._id}`,
                            headers: {
                                'Content-type': 'application/json',
                                'Authorization': authHeaders
                            },
                            success: load
                        })
                    }
                }

                $('#main')
                    .append(outerContainer)
            })
    }
}