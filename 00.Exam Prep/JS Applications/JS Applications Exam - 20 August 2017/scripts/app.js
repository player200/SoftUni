$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs')

        this.get('index.html', loadHome)
        this.get('#/home', loadHome)

        this.post('#/register', registerUser)
        this.post('#/login', loginUser)
        this.get('#/logout', logoutUser)

        this.get('#/catalog', loadCatalog)

        this.get('#/create/post', loadCreate)
        this.post('#/create/post', createPost)

        this.get('#/edit/post/:postId', loadEditPost)
        this.post('#/edit/post', editPost)

        this.get('#/delete/post/:postId', deletePost)

        this.get('#/my/post', loadMyPosts)

        this.get('#/details/:postId', loadDetails)

        this.post('#/create/comment/:postId', createComment)

        this.get('#/delete/comment/:commentId/post/:postId', deleteComment)
    })

    function deleteComment(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let commentId = ctx.params.commentId
        let postId = ctx.params.postId

        comments.commentToDelete(commentId)
            .then(function () {
                notify.showInfo('Successfully deleted comment.')
                ctx.redirect('#/details/' + postId)
            })
            .catch(notify.handleError)
    }

    function createComment(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let content = ctx.params.content
        let author = sessionStorage.getItem('username')
        let postId = ctx.params.postId

        if (content === '') {
            notify.showError('You should fill content form.')
        }
        else {
            comments.creteComments(author, content, postId)
                .then(function () {
                    notify.showInfo('Successfully created comment.')
                    ctx.redirect('#/details/' + postId)
                })
                .catch(notify.handleError)
        }
    }

    function loadDetails(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let postId = this.params.postId
        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')

        const postPromise = posts.getPostById(postId)
        const allCommentsPromise = comments.getCurrentComments(postId)

        Promise.all([postPromise, allCommentsPromise])
            .then(function ([post, comments]) {
                post.date = posts.calcTime(post._kmd.ect)
                post.isAuthor = post._acl.creator === sessionStorage.getItem('userId')

                if (comments.length > 0) {
                    comments.forEach((c) => {
                        c.commentData = posts.calcTime(c._kmd.ect)
                        c.commentAuthor = c._acl.creator === sessionStorage.getItem('userId')
                    })
                }

                ctx.post = post
                ctx.comments = comments

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/posts/details.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function loadMyPosts(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')

        posts.getMyPosts(sessionStorage.getItem('username'))
            .then(function (postData) {
                postData.forEach((p, i) => {
                    p.rank = i + 1
                    p.date = posts.calcTime(p._kmd.ect)
                    p.isAuthor = p._acl.creator === sessionStorage.getItem('userId')
                })

                ctx.posts = postData

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/posts/my-posts.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function deletePost(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let postId = ctx.params.postId

        posts.postToDelete(postId)
            .then(function () {
                notify.showInfo('Successfully deleted post.')
                ctx.redirect('#/catalog')
            })
            .catch(notify.handleError)
    }

    function editPost(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let postId = this.params.postId
        let author = sessionStorage.getItem('username')
        let url = ctx.params.url
        let imageUrl = ctx.params.imageUrl
        let title = ctx.params.title
        let description = ctx.params.description

        if (url === ''
            || title === '') {
            notify.showError('Url and Title fields should be non-empty!')
        }
        else {
            posts.editPost(postId, author, url, title, imageUrl, description)
                .then(function () {
                    notify.showInfo(`Successfully edited ${title}.`)
                    ctx.redirect('#/catalog')
                })
                .catch(notify.handleError)
        }
    }

    function loadEditPost(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let postId = this.params.postId
        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')

        posts.getPostById(postId)
            .then(function (postData) {
                ctx.post = postData

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/posts/edit-post.hbs')
                    })
            })
    }

    function createPost(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let author = sessionStorage.getItem('username')
        let url = ctx.params.url
        let imageUrl = ctx.params.imageUrl
        let title = ctx.params.title
        let description = ctx.params.description

        if (url === ''
            || title === '') {
            notify.showError('Url and Title fields should be non-empty!')
        }
        else {
            posts.createPost(author, url, title, imageUrl, description)
                .then(function (userData) {
                    notify.showInfo('Post created.')
                    ctx.redirect('#/catalog')
                })
                .catch(notify.handleError)
        }
    }

    function loadCreate(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            navigation: './templates/common/navigation.hbs'
        })
            .then(function () {
                this.partial('./templates/posts/create-post.hbs')
            })
    }

    function loadCatalog(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')

        posts.loadPosts()
            .then(function (postData) {
                postData.forEach((p, i) => {
                    p.rank = i + 1
                    p.date = posts.calcTime(p._kmd.ect)
                    p.isAuthor = p._acl.creator === sessionStorage.getItem('userId')
                })

                ctx.posts = postData

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                })
                    .then(function () {
                        this.partial('./templates/posts/catalog.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function logoutUser(ctx) {
        auth.logout()
            .then(function () {
                sessionStorage.clear()
                notify.showInfo('Logout successful.')
                ctx.redirect('#/home')
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
                    ctx.redirect('#/catalog')
                })
                .catch(notify.handleError)
        }
    }

    function registerUser(ctx) {
        let username = this.params.username
        let password = this.params.password
        let repeatPassword = this.params.repeatPass

        if (!/^[A-Za-z]{3,}$/.test(username)) {
            notify.showError('Username should be at least 3 characters long and contain only english alphabet letters')
        }
        else if (!/^[A-Za-z\d]{6,}$/.test(password)) {
            notify.showError('Password should be at least 6 characters long and contain only english alphabet letters')
        }
        else if (repeatPassword !== password) {
            notify.showError('Passwords must match!')
        }
        else {
            auth.register(username, password, repeatPassword)
                .then(function (userData) {
                    auth.saveSession(userData)
                    notify.showInfo('User registration successful!')
                    ctx.redirect('#/catalog')
                })
                .catch(notify.handleError)
        }
    }

    function loadHome(ctx) {
        if (!auth.isAuth()) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs',
                registerForm: './templates/register/registerForm.hbs'
            })
                .then(function () {
                    this.partial('./templates/homepage.hbs')
                })
        }
        else {
            ctx.redirect('#/catalog')
        }

    }

    app.run()
})