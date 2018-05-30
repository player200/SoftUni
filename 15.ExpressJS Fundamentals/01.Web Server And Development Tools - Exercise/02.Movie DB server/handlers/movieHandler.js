const url = require('url')
const fs = require('fs')
const movies = require('../config/dataBase')
const qs = require('querystring')

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname

    if (req.pathname === '/viewAllMovies' && req.method === 'GET') {
        fs.readFile('./views/viewAll.html', 'utf8', (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                })

                res.write('404 not found!')
                res.end()
                return
            }
            let resultHtml = ''
            let counter = 0
            for (let movie of movies) {
                let template = `
            
                <div class="movie">
                    <a href="/movies/details/{{index}}">
                    <img class="moviePoster" src="{{posterUrl}}" />
                    </a>
                </div>
            `

                template = template.replace('{{index}}', counter)
                template = template.replace('{{posterUrl}}', decodeURIComponent(movie.moviePoster))
                resultHtml += template
                counter++
            }

            const placeholder = '<div id="replaceMe">{{replaceMe}}</div>'
            data = data.replace(placeholder, resultHtml)

            res.writeHead(200, {
                'Content-Type': 'text/html'
            })
            res.write(data)
            res.end()
        })
    } else if (req.pathname === '/addMovie' && req.method === 'GET') {
        fs.readFile('./views/addMovie.html', 'utf8', (err, data) => {
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
            res.write(data)
            res.end()
        })
    } else if (req.pathname === '/addMovie' && req.method === 'POST') {
        let body = []
        req.on('data', (data) => {
            body.push(data)
        })
        req.on('end', () => {
            let dataString = Buffer
                .concat(body)
                .toString()

            data = qs.parse(dataString)
            if (!data.movieTitle || !data.moviePoster) {
                fs.readFile('./views/addMovie.html', 'utf8', (err, data) => {
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

                    const placeholder = '<div id="replaceMe">{{replaceMe}}</div>'
                    data = data.replace(placeholder, '<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>')

                    res.write(data)
                    res.end()
                })
                return
            }

            movies.push(data)
            fs.readFile('./views/addMovie.html', 'utf8', (err, data) => {
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

                const placeholder = '<div id="replaceMe">{{replaceMe}}</div>'
                data = data.replace(placeholder, '<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>')

                res.write(data)
                res.end()
            })
        })

    } else if (req.pathname.startsWith('/movies/details/') && req.method === 'GET') {
        let index = parseInt(req.pathname.substr(req.pathname.lastIndexOf('/') + 1))
        fs.readFile('./views/viewAll.html', 'utf8', (err, data) => {
            if (err || index > movies.length - 1) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                })

                res.write('404 not found!')
                res.end()
                return
            }
            let movie = movies[index]

            let template = `
                <div class="content">
                    <img src="{{url}}" alt=""/>
                    <h3>Title  {{title}}</h3>
                    <h3>Year {{year}}</h3>
                    <p> {{description}}</p>
                </div>`

            template = template.replace('{{url}}', decodeURIComponent(movie.moviePoster))
            template = template.replace('{{title}}', decodeURIComponent(movie.movieTitle))
            template = template.replace('{{year}}', decodeURIComponent(movie.movieYear))
            template = template.replace('{{description}}', decodeURIComponent(movie.movieDescription))

            const placeholder = '<div id="replaceMe">{{replaceMe}}</div>'
            data = data.replace(placeholder, template)

            res.writeHead(200, {
                'Content-Type': 'text/html'
            })
            res.write(data)
            res.end()
        })
    } else {
        return true
    }
}