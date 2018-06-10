const fs = require('fs')
const path = require('path')
const Book = require('../models/Book')

module.exports.index = (req, res) => {
    Book.find({}).then(books => {
        let count = books.length === undefined ? 0 : books.length
        res.render('home/index', { count: count })
    })
}