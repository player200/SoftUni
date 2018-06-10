const mongoose = require('mongoose')

let genreSheme = mongoose.Schema({
    title: { type: mongoose.Schema.Types.String },
    memes: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Meme' }]
})

let Genre = mongoose.model('Genre', genreSheme)

module.exports = Genre