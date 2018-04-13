let auth = (() => {
    function isAuth() {
        return sessionStorage.getItem('authtoken') !== null
    }

    function saveSession(userData) {
        sessionStorage.setItem('authtoken', userData._kmd.authtoken)
        sessionStorage.setItem('username', userData.username)
        sessionStorage.setItem('userId', userData._id)
    }

    function login(username, password) {
        let userData = {
            username,
            password
        }

        return requester.post('user', 'login', 'basic', userData)
    }

    function register(username, password, repeatPassword) {
        let userData = {
            username,
            password
        }

        return requester.post('user', '', 'basic', userData)
    }

    function logout() {
        let logoutData = {
            authtoken: sessionStorage.getItem('authtoken')
        }

        return requester.post('user', '_logout', 'kinvey', logoutData)
    }

    return {
        isAuth,
        login,
        register,
        logout,
        saveSession
    }
})()