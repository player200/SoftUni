let posts = (() => {
    function loadPosts() {
        let endpoint = 'posts?query={}&sort={"_kmd.ect": -1}'

        return requester.get('appdata', endpoint, 'kinvey')
    }

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

    function createPost(author, url, title, imageUrl, description) {
        let data = {
            author,
            url,
            title,
            imageUrl,
            description
        }

        return requester.post('appdata', 'posts', 'kinvey', data)
    }

    function editPost(postId, author, url, title, imageUrl, description) {
        let data = {
            author,
            url,
            title,
            imageUrl,
            description
        }

        return requester.update('appdata', 'posts/' + postId, 'kinvey', data)
    }

    function getPostById(postId) {
        return requester.get('appdata', 'posts/' + postId, 'kinvey')
    }

    function postToDelete(postId) {
        let endpoint = `posts/${postId}`

        return requester.remove('appdata', endpoint, 'kinvey')
    }

    function getMyPosts(username) {
        let endpoint=`posts?query={"author":"${username}"}&sort={"_kmd.ect": -1}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    return {
        loadPosts,
        calcTime,
        createPost,
        postToDelete,
        getPostById,
        editPost,
        getMyPosts
    }
})()