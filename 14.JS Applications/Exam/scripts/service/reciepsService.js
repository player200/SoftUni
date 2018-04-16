let recieps = (() => {
    function createReciep() {
        let data = {
            active: true,
            productCount: 0,
            total: 0
        }

        return requester.post('appdata', 'receipts', 'kinvey', data)
    }

    function editReciep(reciepId, productCount, total) {
        let data = {
            active: false,
            productCount: productCount,
            total: total
        }

        return requester.update('appdata', 'receipts/' + reciepId, 'kinvey', data)
    }

    function getActiveReciep(userId) {
        let endpoint = `receipts?query={"_acl.creator":"${userId}","active":"true"}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    function getAllMyReceiptsUnactive(userId) {
        let endpoint = `receipts?query={"_acl.creator":"${userId}","active":"false"}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    return {
        getActiveReciep,
        createReciep,
        editReciep,
        getAllMyReceiptsUnactive
    }
})()