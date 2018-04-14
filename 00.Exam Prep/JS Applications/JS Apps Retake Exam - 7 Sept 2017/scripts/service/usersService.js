let users = (() => {
    function listAllUsers() {
        return requester.get('user', '', 'kinvey')
    }

    function updateUser(userId, following) {
        let data = {
            subscriptions: following
        };

        return requester.update('user', userId, 'kinvey', data)
    }

    return {
        listAllUsers,
        updateUser
    }
})()