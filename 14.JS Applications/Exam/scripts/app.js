$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs')

        this.get('index.html', loadRegisterLoginPage)
        this.get('#/home', loadHome)

        this.post('#/register', registerUser)
        this.post('#/login', loginUser)
        this.get('#/logout', logoutUser)

        this.post('#/create/entry', createEntry)

        this.get('#/delete/entry/:entryId', deleteEntry)

        this.post('#/update/receipt/:receiptId', updateReceipt)

        this.get('#/all/receipts', listAllReceipt)

        this.get('#/details/receipt/:receiptId', detailsReceipt)
    })

    function detailsReceipt(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')
        ctx.currentActiveReceiptId = sessionStorage.getItem('receiptId')

        let receiptId = this.params.receiptId

        entries.getAllEntriesByReciepsId(receiptId)
            .then(function (data) {
                data.forEach(c => {
                    c.totalPrice = (c.qty * c.price).toFixed(2)
                })

                ctx.entries = data

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs'
                })
                    .then(function () {
                        this.partial('./templates/receipts/details.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function listAllReceipt(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        ctx.isAuth = auth.isAuth()
        ctx.username = sessionStorage.getItem('username')
        ctx.currentActiveReceiptId = sessionStorage.getItem('receiptId')

        let userId = sessionStorage.getItem('userId')

        recieps.getAllMyReceiptsUnactive(userId)
            .then(function (data) {
                ctx.receipts = data

                let total = 0
                for (let currentData of data) {
                    total += Number(currentData.total)
                }

                data.forEach(c => {
                    c.cretedTime = (c._kmd.ect.replace('T', ' ')).substr(0, 16)
                })

                ctx.totalTotalPrice = Number(total).toFixed(2)

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs'
                })
                    .then(function () {
                        this.partial('./templates/receipts/all-receipts.hbs')
                    })
            })
            .catch(notify.handleError)
    }

    function updateReceipt(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let receiptId = this.params.receiptId
        let productCount = ctx.params.productCount
        let total = ctx.params.total


        if (Number(productCount) === 0) {
            notify.showError('There should be at least one entry to checkout that receipt.')
            ctx.redirect('#/home')
            return
        }

        recieps.editReciep(receiptId, productCount, total)
            .then(function () {
                notify.showInfo('Receipt checked out')
                sessionStorage.setItem('receiptId', null)
                ctx.redirect('#/home')
            })
            .catch(notify.handleError)
    }

    function deleteEntry(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let entryId = this.params.entryId

        entries.entrieToDelete(entryId)
            .then(function () {
                notify.showInfo('Entry removed')
                ctx.redirect('#/home')
            })
            .catch(notify.handleError)
    }

    function createEntry(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }

        let type = ctx.params.type
        let qty = ctx.params.qty
        let price = ctx.params.price
        let receiptId = ctx.params.receiptIdCreate

        if (type === ''
            || qty === ''
            || price === '') {
            notify.showError('All fields should not be empty!')
        }
        else if (isNaN(qty)) {
            notify.showError('Quntity should be number!')
        }
        else if (isNaN(price)) {
            notify.showError('Price should be number!')
        }
        else {
            entries.createEnt(type, Number(qty), Number(price).toFixed(2), receiptId)
                .then(function () {
                    notify.showInfo('Entry added')
                    ctx.redirect('#/home')
                })
                .catch(notify.handleError)
        }
    }

    function logoutUser(ctx) {
        if (!auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }
        auth.logout()
            .then(function () {
                sessionStorage.clear()
                notify.showInfo('Logout successful.')
                loadRegisterLoginPage(ctx)
            })
            .catch(notify.handleError)
    }

    function loginUser(ctx) {
        if (auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }
        let username = this.params.usernameLogin
        let password = this.params.passwordLogin

        if (username.length < 5) {
            notify.showError('Username should be at least 5 characters long!')
        }
        else if (password === '') {
            notify.showError('Password should not be empty!')
        }
        else {
            auth.login(username, password)
                .then(function (userData) {
                    auth.saveSession(userData)
                    notify.showInfo('Login successful.')
                    ctx.redirect('#/home')
                })
                .catch(notify.handleError)
        }
    }

    function registerUser(ctx) {
        if (auth.isAuth()) {
            ctx.redirect('#/home')
            return
        }
        let username = this.params.usernameRegister
        let password = this.params.passwordRegister
        let repeatPassword = this.params.passwordRegisterCheck

        if (username.length < 5) {
            notify.showError('Username should be at least 5 characters long!')
        }
        else if (password === ''
            || repeatPassword === '') {
            notify.showError('Password should not be empty!')
        }
        else if (repeatPassword !== password) {
            notify.showError('Passwords must match!')
        }
        else {
            auth.register(username, password, repeatPassword)
                .then(function (userData) {
                    auth.saveSession(userData)
                    notify.showInfo('User registration successful!')
                    ctx.redirect('#/home')
                })
                .catch(notify.handleError)
        }
    }

    function haveActive(currentUserId) {
        return recieps.getActiveReciep(currentUserId)
    }

    function createR() {
        return recieps.createReciep()
            .then(function () {
            })
            .catch(notify.handleError)
    }

    async function loadHome(ctx) {
        if (auth.isAuth()) {
            let currentUserId = sessionStorage.getItem('userId')

            ctx.isAuth = auth.isAuth()
            ctx.username = sessionStorage.getItem('username')

            let active = await haveActive(currentUserId)
            if (active.length === 0) {
                let create = await createR()
            }

            let currentActive = await haveActive(currentUserId)
            let receiptId = currentActive[0]._id
            sessionStorage.setItem('receiptId', receiptId)

            entries.getAllEntriesByReciepsId(receiptId)
                .then(function (data) {
                    data.forEach(c => {
                        c.totalPrice = (c.qty * c.price).toFixed(2)
                    })

                    let total = 0
                    for (let currentData of data) {
                        total += Number(currentData.totalPrice)
                    }

                    ctx.isAuth = auth.isAuth()
                    ctx.username = sessionStorage.getItem('username')
                    ctx.receiptId = receiptId
                    ctx.entries = data
                    ctx.totalMoney = total === undefined ? 0 : Number(total).toFixed(2)
                    ctx.countProducts = data.length
                    ctx.currentActiveReceiptId = sessionStorage.getItem('receiptId')

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs'
                    })
                        .then(function () {
                            this.partial('./templates/homepage.hbs')
                        })
                })
                .catch(notify.handleError)
        }
        else {
            loadRegisterLoginPage(ctx)
        }

    }

    function loadRegisterLoginPage(ctx) {
        if (!auth.isAuth()) {
            ctx.loadPartials({
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs',
                registerForm: './templates/register/registerForm.hbs'
            })
                .then(function () {
                    this.partial('./templates/common/login-register-page.hbs')
                })
        }
        else {
            ctx.redirect('#/home')
        }
    }

    app.run()
})