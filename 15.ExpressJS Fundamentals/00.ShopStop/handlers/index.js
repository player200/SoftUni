const homeHandler = require('./home')
const staticFileHandler = require('./static-files')
const productHandler = require('./product')

module.exports = [homeHandler, staticFileHandler, productHandler]