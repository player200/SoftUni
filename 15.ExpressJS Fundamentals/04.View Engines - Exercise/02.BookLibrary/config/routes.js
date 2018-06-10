const handlers = require('../handlers')

module.exports = (app) => {
    app.get('/', handlers.home.index)

    app.get('/viewAllBooks', handlers.bookHandler.viewAll)
    app.get('/addBook', handlers.bookHandler.addBook)
    app.post('/addBook', handlers.bookHandler.addBookPost)
    app.get('/books/details/:id', handlers.bookHandler.getDetails)
}