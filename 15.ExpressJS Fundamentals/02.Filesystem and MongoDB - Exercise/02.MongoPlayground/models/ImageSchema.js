const mongoose = require('mongoose')

let imageSheme = mongoose.Schema({
    url: { type: mongoose.Schema.Types.String, required: true },
    creationdate: { type: mongoose.Schema.Types.Date },
    description: { type: mongoose.Schema.Types.String },
    tags: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Tag' }]
})

let Image = mongoose.model('Image', imageSheme)

module.exports = Image