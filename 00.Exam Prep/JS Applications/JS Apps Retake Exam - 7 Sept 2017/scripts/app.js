$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs')

        this.get('skeleton.html', loadRegister)

        this.get('#/register', loadRegister)
        this.post('#/register', registerUser)

        this.get('#/login', loadLogin)
        this.post('#/login', loginUser)

        this.get('#/logout', logoutUser)

        this.get('#/feed', loadFeeds)

        this.post('#/create/chirp', createChip)

        this.get('#/me/chirps', loadMeChirps)

        this.get('#/delete/chirp/:chirpId', deleteChirp)

        this.get('#/discover', loadDiscover)

        this.get('#/user/details/:author', loadDetails)

        this.get('#/user/follow/:author', followUser)

        this.get('#/user/unfollow/:author', unfollowUser)
    })

    function unfollowUser(ctx) {
        let userForFollow = ctx.params.author
        let userId = sessionStorage.getItem('userId')
        let following = JSON.parse(sessionStorage.getItem('subscriptions'))
        let index = following.indexOf(userForFollow)
        following.splice(index, 1)

        users.updateUser(userId, following)
            .then(function () {
                notify.showInfo(`Unsubscribed to ${userForFollow}`)
                sessionStorage.setItem('subscriptions', JSON.stringify(following))
                ctx.redirect(`#/user/details/${userForFollow}`)
            })
            .catch(notify.handleError)
    }

    function followUser(ctx) {
        let userForFollow = ctx.params.author
        let userId = sessionStorage.getItem('userId')
        let following = JSON.parse(sessionStorage.getItem('subscriptions'))
        following.push(userForFollow)

        users.updateUser(userId, following)
            .then(function () {
                notify.showInfo(`Subscribed to ${userForFollow}`)
                sessionStorage.setItem('subscriptions', JSON.stringify(following))
                ctx.redirect(`#/user/details/${userForFollow}`)
            })
            .catch(notify.handleError)
    }

    function loadDetails(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        let author = ctx.params.author
        ctx.author = author
        ctx.isAuth = auth.isAuth()
        ctx.isAuthor = author === sessionStorage.getItem('username')

        Promise.all([chips.loadAllChirpsByUsername(author), auth.loadUserFollowers(author)])
            .then(function ([chirpsArr, followersArr]) {
                chirpsArr.forEach(c => {
                    c.date = chips.calcTime(c._kmd.ect)
                })

                ctx.chirps = chirpsArr
                ctx.chirpsCount = chirpsArr.length
                ctx.following = JSON.parse(sessionStorage.getItem('subscriptions')).length
                ctx.followers = followersArr.length
                ctx.notFollowed = sessionStorage.getItem('subscriptions').includes(author) === true ? false : true

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/user/detail.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function loadDiscover(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        ctx.isAuth = auth.isAuth()

        users.listAllUsers()
            .then(function (userData) {
                userData
                    .forEach(user => {
                        user.followers = userData
                            .filter(u => u.subscriptions.includes(user.username)).length
                    })
                userData = userData
                    .filter(u => u.username !== sessionStorage.getItem('username'))
                ctx.users = userData
                    .sort((a, b) => b.followers - a.followers)


                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/discover/discover-all.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function deleteChirp(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        let chirpId = ctx.params.chirpId

        chips.chirpToDelete(chirpId)
            .then(function () {
                notify.showInfo('Successfully deleted chirp.')
                ctx.redirect('#/me/chirps')
            })
            .catch(notify.handleError)
    }

    function loadMeChirps(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        let username = sessionStorage.getItem('username')

        Promise.all([chips.loadAllChirpsByUsername(username), auth.loadUserFollowers(username)])
            .then(function ([chirpsArr, followersArr]) {
                chirpsArr.forEach(c => {
                    c.date = chips.calcTime(c._kmd.ect)
                    c.isAuthor = true
                })

                ctx.username = username
                ctx.isAuth = auth.isAuth()
                ctx.chips = chirpsArr
                ctx.countChips = chirpsArr.length
                ctx.following = JSON.parse(sessionStorage.getItem('subscriptions')).length
                ctx.followers = followersArr.length

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/homepage.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function createChip(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        let text = ctx.params.text
        let author = sessionStorage.getItem('username')

        if (text.length > 150) {
            notify.showError('Text cannot be more than 150 symbols.')
        }
        else {
            chips.crete(text, author)
                .then(function () {
                    notify.showInfo('Successfully created chirp.')
                    ctx.redirect('#/me/chirps')
                })
                .catch(notify.handleError)
        }
    }

    function logoutUser(ctx) {
        auth.logout()
            .then(function () {
                sessionStorage.clear()
                notify.showInfo('Logout successful.')
                loadFeeds(ctx)
            })
            .catch(notify.handleError)
    }

    function loginUser(ctx) {
        let username = this.params.username
        let password = this.params.password

        if (username === ''
            || password === '') {
            notify.showError('All fields should be non-empty!')
        }
        else {
            auth.login(username, password)
                .then(function (userData) {
                    auth.saveSession(userData)
                    notify.showInfo('Login successful.')
                    ctx.redirect('#/feed')
                })
                .catch(notify.handleError)
        }
    }

    function loadLogin(ctx) {
        if (!auth.isAuth()) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            })
                .then(function () {
                    this.partial('./templates/login/loginForm.hbs')
                })
        }
        else {
            ctx.redirect('#/home')
        }
    }

    function registerUser(ctx) {
        let username = this.params.username
        let password = this.params.password
        let repeatPassword = this.params.repeatPass

        if (username.length < 5) {
            notify.showError('Username should be at least 5 characters long.')
        }
        else if (password.length < 5) {
            notify.showError('Password should be at least 5 characters long.')
        }
        else if (repeatPassword !== password) {
            notify.showError('Passwords must match!')
        }
        else {
            auth.register(username, password, repeatPassword)
                .then(function (userData) {
                    auth.saveSession(userData)
                    notify.showInfo('User registration successful!')
                    ctx.redirect('#/feed')
                })
                .catch(notify.handleError)
        }
    }

    function loadRegister(ctx) {
        if (!auth.isAuth()) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            })
                .then(function () {
                    this.partial('./templates/register/registerForm.hbs')
                })
        }
        else {
            ctx.redirect('#/home')
        }
    }

    function loadFeeds(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/feed')
            return
        }

        let subsArr = JSON.parse(sessionStorage.getItem('subscriptions')).map(e => `"${e}"`)
        let username = sessionStorage.getItem('username')

        Promise.all([chips.loadAllChirpsByUsername(username), auth.loadUserFollowers(username)])
            .then(function ([chirpsArr, followersArr]) {
                chips.getAllChips(subsArr)
                    .then(function (data) {
                        data.forEach(c => {
                            c.date = chips.calcTime(c._kmd.ect)
                        })

                        ctx.username = username
                        ctx.isAuth = auth.isAuth()
                        ctx.chips = data
                        ctx.countChips = chirpsArr.length
                        ctx.following = JSON.parse(sessionStorage.getItem('subscriptions')).length
                        ctx.followers = followersArr.length
                        ctx.isAuthor = auth.isAuth()

                        ctx.loadPartials({
                            header: './templates/common/header.hbs',
                            footer: './templates/common/footer.hbs',
                            navigation: './templates/common/navigation.hbs'
                        })
                            .then(function () {
                                this.partial('./templates/homepage.hbs')
                            })
                    })
                    .catch(notify.handleError)
            })
            .catch(notify.handleError)
    }

    app.run()
})