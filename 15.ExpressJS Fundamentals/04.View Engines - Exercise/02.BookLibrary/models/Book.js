const mongoose = require('mongoose')

let bookSheme = mongoose.Schema({
    title: { type: mongoose.Schema.Types.String, required: true },
    url: { type: mongoose.Schema.Types.String, required: true },
    releasedate: { type: mongoose.Schema.Types.String },
    author: { type: mongoose.Schema.Types.String }
})

let Book = mongoose.model('Book', bookSheme)

module.exports = Book