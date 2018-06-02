const homeHandler = require('./home')
const staticFileHandler = require('./static-files')
const productHandler = require('./product')
const categoryHandler = require('./category')

module.exports = [homeHandler, staticFileHandler, productHandler, categoryHandler]