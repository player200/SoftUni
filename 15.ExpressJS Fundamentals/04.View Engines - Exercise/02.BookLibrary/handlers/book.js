const fs = require('fs')
const path = require('path')
const Book = require('../models/Book')

module.exports.viewAll = (req, res) => {
    Book.find({}).then(books => {
        res.render('book/viewAll', { books: books })
    })
}

module.exports.addBook = (req, res) => {
    res.render('book/addBook')
}

module.exports.addBookPost = (req, res) => {
    let bookObj = req.body

    if (!bookObj.bookTitle || !bookObj.bookPoster) {
        res.render('book/addBook', { error: true })
    }
    let transformedObj = {
        title: bookObj.bookTitle,
        url: bookObj.bookPoster,
        releasedate: bookObj.bookYear,
        author: bookObj.bookAuthor
    }

    Book.create(transformedObj)
        .then(data => {
            res.render('book/addBook', { success: true })
        })
}

module.exports.getDetails = (req, res) => {
    let id = req.params.id

    Book.findById(id)
        .then(book => {
            res.render('book/details', { book: book })
        })
        .catch(err => {
            console.log(err)
        })
}