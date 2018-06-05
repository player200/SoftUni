const mongoose = require('mongoose')

let tagSheme = mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, unique: true, required: true },
    creationdate: { type: mongoose.Schema.Types.Date },
    images: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Image' }]
})

let Tag = mongoose.model('Tag', tagSheme)

module.exports = Tag