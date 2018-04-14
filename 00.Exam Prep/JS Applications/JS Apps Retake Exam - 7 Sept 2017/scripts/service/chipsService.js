let chips = (() => {
    function calcTime(dateIsoFormat) {
        let diff = new Date - (new Date(dateIsoFormat))
        diff = Math.floor(diff / 60000)
        if (diff < 1) {
            return 'less than a minute'
        }

        if (diff < 60) {
            return diff + ' minute' + pluralize(diff)
        }

        diff = Math.floor(diff / 60)
        if (diff < 24) {
            return diff + ' hour' + pluralize(diff)
        }

        diff = Math.floor(diff / 24)
        if (diff < 30) {
            return diff + ' day' + pluralize(diff)
        }

        diff = Math.floor(diff / 30)
        if (diff < 12) {
            return diff + ' month' + pluralize(diff)
        }

        diff = Math.floor(diff / 12)

        return diff + ' year' + pluralize(diff)

        function pluralize(value) {
            if (value !== 1) {
                return 's'
            }
            else {
                return ''
            }
        }
    }

    function getAllChips(subs) {
        let endpoint = `chirps?query={"author":{"$in": [${subs}]}}&sort={"_kmd.ect": -1}`;

        return requester.get('appdata', endpoint, 'kinvey');
    }
    function loadAllChirpsByUsername(username) {
        let endpoint = `chirps?query={"author":"${username}"}&sort={"_kmd.ect": -1}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    function crete(text, author) {
        let data = {
            text,
            author
        }

        return requester.post('appdata', 'chirps', 'kinvey', data)
    }

    function chirpToDelete(chirpId) {
        let endpoint = `chirps/${chirpId}`

        return requester.remove('appdata', endpoint, 'kinvey')
    }

    return {
        calcTime,
        getAllChips,
        loadAllChirpsByUsername,
        crete,
        chirpToDelete
    }
})()