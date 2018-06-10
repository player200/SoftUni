const express = require('express')
const path = require('path')
const bodyParser = require('body-parser')

module.exports = (app, config) => {
    app.set('view engine', 'pug')
    app.set('views', path.join(config.rootPath, 'views'))

    app.use(bodyParser.urlencoded({ extended: true }))

    app.use((req, res, next) => {
        if (req.url.startsWith('/static')) {
            req.url = req.url.replace('/static', '')
        }

        next()
    }, express.static(
        path.normalize(
            path.join(config.rootPath, 'static')
        )
    ))
}