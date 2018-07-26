const User = require('../models/User')
const encryption = require('../utilities/encryption')

module.exports.registerGet = (req, res) => {
    if (!req.user) {
        res.render('user/register')
        return
    }

    res.redirect('/')
}

module.exports.registerPost = (req, res) => {
    if (!req.user) {
        let user = req.body

        if (user.password && user.password !== user.confirmedPassword) {
            user.error = 'Passwords do not match.'
            res.render('user/register', user)
            return
        }

        let salt = encryption.generateSalt()
        user.salt = salt

        if (user.password) {
            let hashedPassword = encryption.generateHashedPassword(salt, user.password)
            user.password = hashedPassword
        }

        User.create(user)
            .then(user => {
                req.logIn(user, (error, user) => {
                    if (error) {
                        res.render('user/register', { error: 'Authentication not working!' })

                        return
                    }

                    res.redirect('/')
                })
            }).catch(error => {
                user.error = error
                res.render('user/register', user)
            })

        return
    }

    res.redirect('/')
}

module.exports.loginGet = (req, res) => {
    if (!req.user) {
        res.render('user/login')
        return
    }

    res.redirect('/')
}

module.exports.loginPost = (req, res) => {
    if (!req.user) {
        let userLogin = req.body

        User.findOne({ username: userLogin.username })
            .then(user => {
                if (!user || !user.authenticate(userLogin.password)) {
                    res.render('user/login', { error: 'Invalid credentials!' })
                } else {
                    req.logIn(user, (error, user) => {
                        if (error) {
                            res.render('user/login', { error: 'Authentication not working!' })

                            return
                        }

                        res.redirect('/')
                    })
                }
            }).catch(error => {
                console.log(error)
                res.render('user/login', { error: error })
            })
        return
    }

    res.redirect('/')
}

module.exports.logout = (req, res) => {
    req.logout()
    res.redirect('/')
}