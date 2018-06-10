const mongoose = require('mongoose')

let memeSheme = mongoose.Schema({
    title: { type: mongoose.Schema.Types.String },
    memeSrc: { type: mongoose.Schema.Types.String },
    description: { type: mongoose.Schema.Types.String },
    privacy: { type: mongoose.Schema.Types.String },
    dataStamp: { type: mongoose.Schema.Types.Number },
    genreId: { type: mongoose.Schema.Types.String }
})

let Meme = mongoose.model('Meme', memeSheme)

module.exports = Meme