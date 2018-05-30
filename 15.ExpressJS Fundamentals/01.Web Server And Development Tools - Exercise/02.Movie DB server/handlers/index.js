const homeHandler = require('./homeHandler')
const movieHandler = require('./movieHandler')
const statusHandler = require('./statusHandler')
const staticFileHandler = require('./staticHandler')

module.exports = [homeHandler, movieHandler, statusHandler, staticFileHandler]