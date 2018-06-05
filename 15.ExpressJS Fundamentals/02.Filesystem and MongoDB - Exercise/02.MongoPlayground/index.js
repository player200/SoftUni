const http = require('http')
const url = require('url')
const qs = require('querystring')
const port = process.env.PORT || 5000
const handlers = require('./handlers/handlerBlender')

const config = require('./config/config')
const database = require('./config/database.config')

let environment = process.env.NODE_ENV || 'development'

database(config[environment])

http
  .createServer((req, res) => {
    req.pathname = url.parse(req.url).pathname
    req.pathquery = qs.parse(url.parse(req.url).query)
    for (let handler of handlers) {
      if (!handler(req, res)) {
        break
      }
    }
  })
  .listen(port)
