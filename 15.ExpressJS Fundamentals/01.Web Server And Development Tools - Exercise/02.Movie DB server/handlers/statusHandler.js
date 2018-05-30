const url = require('url')
const fs = require('fs')
const path = require('path')
const movies = require('../config/dataBase')

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname

    if (req.pathname === '/Full' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../views/status.html'))
        fs.readFile(filePath, 'utf8', (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                })

                res.write('404 not found!')
                res.end()
                return
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            })
            let countOfFilms = movies.length

            let template = `<h2>There is ${countOfFilms} at the moment.</h2>`

            const htmlToRemove = `<h1>{{replaceMe}}</h1>`
            data = data.replace(htmlToRemove, template)

            res.write(data)
            res.end()
        })
    } else {
        return true
    }
}