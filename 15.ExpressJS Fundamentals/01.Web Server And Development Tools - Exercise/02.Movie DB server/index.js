const httpContext = require('http')
const handlers = require('./handlers')
const port = 9999

httpContext.createServer((req, res) => {
    for (let handler of handlers) {
        if (!handler(req, res)) {
            break
        }
    }
}).listen(port)