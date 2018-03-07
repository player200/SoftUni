function requestValidator(obj) {
    const METHOD_ITEMS = ['GET', 'POST', 'DELETE', 'CONNECT']
    const VERSION_ITEMS = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']
    const URI_PATTERN = /^([A-Za-z0-9.]+)$/g
    const MESSAGE_PATTERN = /^[^<>\\&'"]+$/g

    if (!(checkMethod(obj))){
        throw new Error('Invalid request header: Invalid Method')
    }

    if (!(checkUri(obj))){
        throw new Error('Invalid request header: Invalid URI')
    }

    if (!(checkVerstion(obj))) {
        throw new Error('Invalid request header: Invalid Version')
    }

    if (!(checkMessage(obj))) {
        throw new Error('Invalid request header: Invalid Message')
    }



    function checkMethod(obj) {
        if (!obj.hasOwnProperty('method')) {
            return false
        }

        return METHOD_ITEMS.includes(obj['method'])
    }

    function checkUri(obj) {
        if (!obj.hasOwnProperty('uri')) {
            return false
        }
        if (obj['uri'] === '') {
            return false
        }

        return URI_PATTERN.test(obj['uri'])
    }

    function checkVerstion(obj) {
        if (!obj.hasOwnProperty('version')) {
            return false
        }

        return VERSION_ITEMS.includes(obj['version'])
    }

    function checkMessage(obj) {
        if (!obj.hasOwnProperty('message')) {
            return false
        }
        if (obj['message'] === '') {
            return true
        }

        return MESSAGE_PATTERN.test(obj['message'])
    }

    return obj
}

requestValidator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'asl<pls'
})