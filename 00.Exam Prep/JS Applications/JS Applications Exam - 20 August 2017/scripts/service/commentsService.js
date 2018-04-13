let comments = (() => {
    function getCurrentComments(postId) {
        let endpoint = `comments?query={"postId":"${postId}"}&sort={"_kmd.ect": -1}`

        return requester.get('appdata', endpoint, 'kinvey')
    }

    function creteComments(author, content, postId) {
        let data = {
            author,
            content,
            postId
        }

        return requester.post('appdata', 'comments', 'kinvey', data)
    }

    function commentToDelete(commentId) {
        let endpoint = `comments/${commentId}`

        return requester.remove('appdata', endpoint, 'kinvey')
    }

    return {
        getCurrentComments,
        creteComments,
        commentToDelete
    }
})()