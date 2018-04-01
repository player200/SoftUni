function attachEvents() {
    let baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook'

    $('#btnLoad').click(loadContacts)

    $('#btnCreate').click(function () {
        if ($('#person').val() === ''
            || $('#phone').val() === '') {
            return
        }

        let newContactJSON = JSON.stringify({
            person: $('#person').val(),
            phone: $('#phone').val()
        })

        $.post(baseUrl + '.json', newContactJSON)
            .then(loadContacts)
            .catch(displayError)

        $('#person').val('')
        $('#phone').val('')
    })

    function loadContacts() {
        $('#phonebook').empty();
        $.get(baseUrl + '.json')
            .then(displayContacts)
            .catch(displayError)
    }

    function displayContacts(contacts) {
        for (let key in contacts) {
            let person = contacts[key]['person']
            let phone = contacts[key]['phone']

            let liText = person + ': ' + phone + ' '
            $('#phonebook')
                .append($(`<li>${liText}</li>`)
                    .append($('<button>Delete</button>')
                        .click(function () {
                            deleteContact(key)
                        })))
        }
    }

    function deleteContact(key) {
        let request = {
            method: 'DELETE',
            url: baseUrl + '/' + key + '.json'
        }

        $.ajax(request)
            .then(loadContacts)
            .catch(displayError)
    }

    function displayError(err) {
        $('#phonebook').append($('<li>Error</li>'))
    }
}