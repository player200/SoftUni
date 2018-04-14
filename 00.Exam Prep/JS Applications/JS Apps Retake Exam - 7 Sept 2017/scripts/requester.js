let requester = (() => {
    const kinveyBaseUrl = "https://baas.kinvey.com/"
    const kinveyAppKey = "kid_r1t6Xrynz"
    const kinveyAppSecret = "168468a899d64031bac3a72204c7903e"

    function makeAuth(type) {
        return type === 'basic'
            ? 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret)
            : 'Kinvey ' + sessionStorage.getItem('authtoken')
    }

    function makeRequest(method, module, endpoint, auth) {
        return req = {
            method,
            url: kinveyBaseUrl + module + '/' + kinveyAppKey + '/' + endpoint,
            headers: {
                'Authorization': makeAuth(auth)
            }
        }
    }

    function get(module, endpoint, auth) {
        return $.ajax(makeRequest('GET', module, endpoint, auth))
    }

    function post(module, endpoint, auth, data) {
        let req = makeRequest('POST', module, endpoint, auth)
        req.data = data
        return $.ajax(req)
    }

    function update(module, endpoint, auth, data) {
        let req = makeRequest('PUT', module, endpoint, auth)
        req.data = data
        return $.ajax(req)
    }

    function remove(module, endpoint, auth) {
        return $.ajax(makeRequest('DELETE', module, endpoint, auth))
    }

    return {
        get,
        post,
        update,
        remove
    }
})()