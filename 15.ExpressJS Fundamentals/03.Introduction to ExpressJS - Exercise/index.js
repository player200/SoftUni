const path = require('path');
const express = require('express');
const bodyParser = require('body-parser')
const fileUploader = require('express-fileupload')
const homeModule = require('./handlers/homeHandler')
const memeModule = require('./handlers/memeHandler')

const port = 2323
const app = express()

app.use('/public', express.static(path.join(__dirname, '/public')))
app.use(bodyParser.urlencoded({ extended: true }))
app.use(fileUploader())

app.use('/', homeModule)
app.use('/memes', memeModule)

require('./config/mongoDb')
  .then(() => {
    app.listen(port, () => console.log('Im listening on ' + port))

  })
  .catch(err => {
    console.log('Could not connect to MongoDb\n', err)
  })