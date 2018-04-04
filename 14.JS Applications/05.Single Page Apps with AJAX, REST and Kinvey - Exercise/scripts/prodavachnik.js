function startApp() {
    const kinveyBaseUrl = 'https://baas.kinvey.com/'
    const appKey = 'kid_Hy5JGGfoG'
    const appSecret = 'c80257991d8a48e7a644c0dd326dd8dc'
    const authHeaders = {
        "Authorization": "Basic " + btoa(appKey + ":" + appSecret)
    }

    $('#linkHome').on('click', homeView)
    $('#linkLogin').on('click', loginView)
    $('#linkRegister').on('click', registerView)
    $('#linkListAds').on('click', listAdsView)
    $('#linkCreateAd').on('click', createAdView)
    $('#linkLogout').on('click', logoutUser)

    function homeView() {
        $('main > section').hide()
        $('#viewHome').show()
    }

    function loginView() {
        $('main > section').hide()
        $('#viewLogin').show()
        $('#formLogin').trigger('reset')
    }

    function registerView() {
        $('#formRegister').trigger('reset')
        $('main > section').hide()
        $('#viewRegister').show()
    }

    function listAdsView() {
        $('#ads').empty()
        $('main > section').hide()
        $('#viewAds').show()

        $.ajax({
            method: 'GET',
            url: kinveyBaseUrl + 'appdata/' + appKey + '/ads',
            headers: currentUserAuthHeaders()
        })
            .then(function (res) {
                res.sort((a, b) => Number(b.views) > Number(a.views))

                if (res.length === 0) {
                    $('#ads')
                        .text('No advertisements available.')
                        .css('text-align', 'center')
                }
                else {
                    let adsTable = $('<table>')
                        .append($('<tr>')
                            .append('<th>Title</th>>')
                            .append('<th>Description</th>')
                            .append('<th>Publisher</th>')
                            .append('<th>Date Published</th>')
                            .append('<th>Price</th>')
                            .append('<th>Actions</th>'))


                    for (let ad of res) {
                        let linksToAdd = []
                        if (ad._acl.creator === sessionStorage['userId']) {
                            let readLink = $('<a href="#">[Read More]</a>')
                                .on('click', function () {
                                    readMoreView(ad)
                                })

                            let deleteLink = $('<a href="#">[Delete]</a>')
                                .on('click', function () {
                                    deleteAd(ad)
                                })
                            let editLink = $('<a href="#">[Edit]</a>')
                                .on('click', function () {
                                    editAdView(ad)
                                })

                            linksToAdd = [readLink, ' ', deleteLink, ' ', editLink]
                        }
                        else {
                            let readLink = $('<a href="#">[Read More]</a>')
                                .on('click', function () {
                                    readMoreView(ad)
                                })

                            linksToAdd = [readLink]
                        }

                        let tdToAdd = $('<td>')
                        tdToAdd
                            .append(linksToAdd)

                        let currentItem = $(`<tr>`)
                            .append($(`<td>${ad.title}</td>`))
                            .append($(`<td>${ad.description}</td>`))
                            .append($(`<td>${ad.publisher}</td>`))
                            .append($(`<td>${ad.datePublished}</td>`))
                            .append($(`<td>${ad.price}</td>`))
                            .append(tdToAdd)

                        adsTable
                            .append(currentItem)
                    }
                    $('#ads')
                        .append(adsTable)
                }
            })
            .catch(handleError)
    }

    function readMoreView(ad) {
        $('main > section').hide()
        $('#viewAdDetails').empty()
        $('#viewAdDetails').show()

        $('#viewAdDetails')
            .append($('<div>')
                .append($('<br>'))
                .append($('<img>').attr('src', ad.image))
                .append($('<br>'))
                .append($('<label>Title: </label>'))
                .append($(`<h1>${ad.title}</h1>`))
                .append($('<label>Description: </label>'))
                .append($(`<p>${ad.description}</p>`))
                .append($('<label>Publisher: </label>'))
                .append($(`<div>${ad.publisher}</div>`))
                .append($('<label>Date: </label>'))
                .append($(`<h1>${ad.datePublished}</h1>`))
                .append($(`<label>Views: ${Number(ad.views) + 1}</label>`)))

        let id = ad._id
        let publisher = ad.publisher
        let title = ad.title
        let description = ad.description
        let datePublished = ad.datePublished
        let price = Number(ad.price).toFixed(2)
        let image = ad.image
        let views = Number(ad.views) + 1

        $.ajax({
            method: 'PUT',
            url: kinveyBaseUrl + 'appdata/' + appKey + '/ads/' + id,
            headers: currentUserAuthHeaders(),
            data: {
                title,
                description,
                publisher,
                datePublished,
                price,
                image,
                views
            }
        })
    }

    function deleteAd(ad) {
        $.ajax({
            method: 'DELETE',
            url: kinveyBaseUrl + 'appdata/' + appKey + '/ads/' + ad._id,
            headers: currentUserAuthHeaders()
        })
            .then(function (res) {
                listAdsView()
                successMessager('Successfully deleted ad.')
            })
            .catch(handleError)
    }

    function editAdView(ad) {
        $('main > section').hide()
        $.ajax({
            method: 'GET',
            url: kinveyBaseUrl + 'appdata/' + appKey + '/ads/' + ad._id,
            headers: currentUserAuthHeaders()
        })
            .then(function (res) {
                console.log(res)
                $('#formEditAd [name=id]').val(res._id)
                $('#formEditAd [name=publisher]').val(res.publisher)
                $('#formEditAd [name=title]').val(res.title)
                $('#formEditAd [name=description]').val(res.description)
                $('#formEditAd [name=datePublished]').val(res.datePublished)
                $('#formEditAd [name=price]').val(res.price)
                $('#formEditAd [name=image]').val(res.image)

                $('#viewEditAd').show()
            })
            .catch(handleError)
    }

    function createAdView() {
        $('#formCreateAd').trigger('reset')
        $('main > section').hide()
        $('#viewCreateAd').show()
    }

    function logoutUser() {
        sessionStorage.clear()
        $('#loggedInUser').text('')
        menuLinks()
        homeView()
        successMessager('You logout successful.')
    }

    $('#buttonLoginUser').on('click', loginUser)
    $('#buttonRegisterUser').on('click', registerUser)
    $('#buttonCreateAd').on('click', createAd)
    $('#buttonEditAd').on('click', editAd)

    function loginUser() {
        let username = $('#formLogin [name=username]').val()
        let password = $('#formLogin [name=passwd]').val()

        if (username === '') {
            loginView()
            errorMessager('You need to use your username to log in!')
        }
        else if (password === '') {
            loginView()
            errorMessager('You need to use your password to log in!')
        }
        else {
            $.ajax({
                method: 'POST',
                url: kinveyBaseUrl + 'user/' + appKey + '/login',
                headers: authHeaders,
                data: {
                    username,
                    password
                }
            })
                .then(function (res) {
                    saveSession(res)
                    menuLinks()
                    listAdsView()
                    successMessager(`Hello ${res.username}.`)
                })
                .catch(handleError)
        }
    }

    function registerUser() {
        let username = $('#formRegister [name=username]').val()
        let password = $('#formRegister [name=passwd]').val()

        if (username === '') {
            registerView()
            errorMessager('You need username to register!')
        }
        else if (password === '') {
            registerView()
            errorMessager('You need password to register!')
        }
        else {
            $.ajax({
                method: 'POST',
                url: kinveyBaseUrl + 'user/' + appKey + '/',
                headers: authHeaders,
                data: {
                    username,
                    password
                }
            })
                .then(function (res) {
                    saveSession(res)
                    menuLinks()
                    listAdsView()
                    successMessager('Successfuly registered user.')
                })
                .catch(handleError)
        }
    }

    function createAd() {
        $.ajax({
            method: 'GET',
            url: kinveyBaseUrl + 'user/' + appKey + '/' + sessionStorage.getItem('userId'),
            headers: currentUserAuthHeaders()
        })
            .then(function (res) {
                let title = $('#formCreateAd [name=title]').val()
                let description = $('#formCreateAd [name=description]').val()
                let publisher = res.username
                let datePublished = $('#formCreateAd [name=datePublished]').val()
                let price = Number($('#formCreateAd [name=price]').val()).toFixed(2)
                let image = $('#formCreateAd [name=image]').val()

                if (title === ''
                    || description === ''
                    || publisher === ''
                    || datePublished === ''
                    || price === ''
                    || image === '') {
                    createAdView()
                    errorMessager('You need to fill all fields!')
                }
                else {
                    $.ajax({
                        method: 'POST',
                        url: kinveyBaseUrl + 'appdata/' + appKey + '/ads',
                        headers: currentUserAuthHeaders(),
                        data: {
                            title,
                            description,
                            publisher,
                            datePublished,
                            price,
                            image,
                            views: 0
                        }
                    })
                        .then(function (res) {
                            listAdsView()
                            successMessager('Ad is created.')
                        })
                        .catch(handleError)
                }
            })
            .catch(handleError)
    }

    function editAd() {
        let id = $('#formEditAd [name=id]').val()
        let publisher = $('#formEditAd [name=publisher]').val()
        let title = $('#formEditAd [name=title]').val()
        let description = $('#formEditAd [name=description]').val()
        let datePublished = $('#formEditAd [name=datePublished]').val()
        let price = Number($('#formEditAd [name=price]').val()).toFixed(2)
        let image = $('#formEditAd [name=image]').val()

        $.ajax({
            method: 'PUT',
            url: kinveyBaseUrl + 'appdata/' + appKey + '/ads/' + id,
            headers: currentUserAuthHeaders(),
            data: {
                title,
                description,
                publisher,
                datePublished,
                price,
                image
            }
        })
            .then(function (res) {
                listAdsView()
                successMessager('Successfully edited ad.')
            })
            .catch(handleError)
    }

    function saveSession(userInfo) {
        let auth = userInfo
            ._kmd
            .authtoken
        sessionStorage.setItem('authToken', auth)
        let userId = userInfo._id
        sessionStorage.setItem('userId', userId)
        let username = userInfo.username
        $('#loggedInUser')
            .text("Welcome, " + username + "!")
    }

    function currentUserAuthHeaders() {
        return {
            "Authorization": "Kinvey " + sessionStorage.getItem('authToken')
        }
    }

    sessionStorage.clear()
    menuLinks()
    homeView()

    function menuLinks() {
        $('#linkHome').show()

        if (sessionStorage.getItem('authToken')) {
            $('#linkLogin').hide()
            $('#linkRegister').hide()
            $('#linkListAds').show()
            $('#linkCreateAd').show()
            $('#linkLogout').show()
            $('#loggedInUser').show()
        }
        else {
            $('#linkLogin').show()
            $('#linkRegister').show()
            $('#linkListAds').hide()
            $('#linkCreateAd').hide()
            $('#linkLogout').hide()
        }
    }

    function handleError(response) {
        let error = JSON.stringify(response)

        if (response.readyState === 0) {
            error = "Error"
        }

        if (response.responseJSON
            && response.responseJSON.description) {
            error = response.responseJSON.description
        }

        errorMessager(error)
    }

    function successMessager(message) {
        $('#infoBox').text(message)
        $('#infoBox').show()
        setTimeout(function () {
            $('#infoBox').fadeOut()
        }, 3000)
    }

    function errorMessager(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg)
        $('#errorBox').show()
        setTimeout(function () {
            $('#errorBox').fadeOut()
        }, 3000)
    }
}