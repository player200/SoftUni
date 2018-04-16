let entries = (() => {
    function getAllEntriesByReciepsId(reciepsId) {
        let endpoint = `entries?query={"receiptId":"${reciepsId}"}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    function createEnt(type, qty, price, receiptId) {
        let data = {
            type,
            qty,
            price,
            receiptId
        }

        return requester.post('appdata', 'entries', 'kinvey', data)
    }

    function entrieToDelete(entryId) {
        let endpoint = `entries/${entryId}`

        return requester.remove('appdata', endpoint, 'kinvey')
    }


    return {
        getAllEntriesByReciepsId,
        createEnt,
        entrieToDelete
    }
})()