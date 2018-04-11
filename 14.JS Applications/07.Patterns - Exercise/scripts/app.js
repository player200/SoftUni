$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs')

        this.get('index.html', loadHome)
        this.get('#/home', loadHome)

        this.get('#/about', loadAbout)

        this.get('#/register', loadRegister)
        this.post('#/register', registerUser)

        this.get('#/login', loadLogin)
        this.post('#/login', loginUser)

        this.get('#/logout', logoutUser)

        this.get('#/catalog', loadCatalog)

        this.get('#/create', loadCreateTeam)
        this.post('#/create', createTeam)

        this.get('#/catalog/:id', loadTeam)

        this.get('#/leave', leaveTeam)

        this.get('#/edit/:id', loadEditTeam)
        this.post('#/edit/:id', editTeam)
    })

    function editTeam(ctx) {
        let teamId = this.params.id.substr(1)
        let name = this.params.name
        let comment = this.params.comment

        teamsService.edit(teamId, name, comment)
            .then(function () {
                auth.showInfo(`Successfully edited team:${name}.`)
                loadCatalog(ctx)
            })
    }

    function loadEditTeam(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')
        ctx.teamId = this.params.id.substr(1)

        teamsService.loadTeamDetails(ctx.teamId)
            .then(function (teamInfo) {
                ctx.name = teamInfo.name
                ctx.comment = teamInfo.comment
                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    editForm: './templates/edit/editForm.hbs'
                })
                    .then(function () {
                        this.partial('./templates/edit/editPage.hbs')
                    })
            })
    }

    function leaveTeam(ctx) {
        teamsService.leaveTeam()
            .then(function (userData) {
                auth.saveSession(userData)
                auth.showInfo('Successfully left team.')
                loadCatalog(ctx)
            })
    }

    function loadTeam(ctx) {
        let teamId = ctx.params.id.substr(1)
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')
        let userTeamId = sessionStorage.getItem('teamId')

        teamsService.loadTeamDetails(teamId)
            .then(function (teamInfo) {
                ctx.name = teamInfo.name
                ctx.comment = teamInfo.comment
                ctx.members = teamInfo.members
                ctx.isAuthor = teamInfo._acl.creator === sessionStorage.getItem('userId')
                ctx.teamId = teamInfo._id
                ctx.isOnTeam = teamInfo._id === userTeamId

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    teamMember: './templates/catalog/teamMember.hbs',
                    teamControls: './templates/catalog/teamControls.hbs'
                })
                    .then(function () {
                        this.partial('./templates/catalog/details.hbs')
                    })
            })
    }

    function createTeam(ctx) {
        let name = this.params.name
        let comment = this.params.comment

        teamsService.createTeam(name, comment)
            .then(function (teamInfo) {
                teamsService.joinTeam(teamInfo._id)
                    .then(function (data) {
                        auth.saveSession(data)
                        auth.showInfo('Successfully created team.')
                        loadCatalog(ctx)
                    })
            })
            .catch(auth.handleError)
    }

    function loadCreateTeam(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            createForm: './templates/create/createForm.hbs'
        })
            .then(function () {
                this.partial('./templates/create/createPage.hbs')
            })
    }

    function loadCatalog(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')
        ctx.hasTeam = sessionStorage.getItem('teamId') !== null
        ctx.hasNoTeam = sessionStorage.getItem('teamId') === null
            || sessionStorage.getItem('teamId') === "undefined"

        teamsService.loadTeams()
            .then(function (teamInfo) {
                ctx.teams = teamInfo

                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    team: './templates/catalog/team.hbs'
                })
                    .then(function () {
                        this.partial('./templates/catalog/teamCatalog.hbs')
                    })
            })
    }

    function logoutUser(ctx) {
        auth.logout()
            .then(function (userInfo) {
                sessionStorage.clear()
                auth.showInfo('Successfully logged out.')
                loadHome(ctx)
            })
            .catch(auth.handleError)
    }

    function loginUser(ctx) {
        let username = this.params.username
        let password = this.params.password

        auth.login(username, password)
            .then(function (userInfo) {
                auth.saveSession(userInfo)
                auth.showInfo('Successfully logged in.')
                loadHome(ctx)
            })
            .catch(auth.handleError)
    }

    function loadLogin(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            loginForm: './templates/login/loginForm.hbs'
        })
            .then(function () {
                this.partial('./templates/login/loginPage.hbs')
            })
    }

    function registerUser(ctx) {
        let username = this.params.username
        let password = this.params.password
        let repeatPassword = this.params.repeatPassword

        if (password === repeatPassword) {
            auth.register(username, password, repeatPassword)
                .then(function (userInfo) {
                    auth.saveSession(userInfo)
                    auth.showInfo('Successfully registered.')
                    loadHome(ctx)
                })
                .catch(auth.handleError)
        }
        else {
            auth.showError(`Password don't match.`)
        }
    }

    function loadRegister(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            registerForm: './templates/register/registerForm.hbs'
        })
            .then(function () {
                this.partial('./templates/register/registerPage.hbs')
            })
    }

    function loadAbout(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs'
        })
            .then(function () {
                this.partial('./templates/about/about.hbs')
            })
    }

    function loadHome(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
        ctx.username = sessionStorage.getItem('username')
        ctx.hasTeam = sessionStorage.getItem('teamId') !== null
        ctx.hasTeam = sessionStorage.getItem('teamId') !== 'undefined'
        if (ctx.hasTeam) {
            ctx.teamId = sessionStorage.getItem('teamId')
        }

        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs'
        })
            .then(function () {
                this.partial('./templates/home/home.hbs')
            })
    }

    app.run()
})