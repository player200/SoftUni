const fs = require('fs')
const url = require('url')
const qs = require('querystring')
const path = require('path')
const router = require('express').Router()
const shortid = require('shortid')
const memeService = require('../services/memeService')
const genreService = require('../services/genreService')

let memeGenerator = (title, memeSrc, description, privacy, genreId) => {
  return {
    title: title,
    memeSrc: memeSrc,
    description: description,
    privacy: privacy,
    dateStamp: Date.now(),
    genreId: genreId
  }
}

let defaultResponse = (respString, res) => {
  res.writeHead(200, {
    'Content-Type': 'text/html'
  })
  res.end(respString)
}

let fieldChecker = obj => {
  for (let prop in obj) {
    if (obj[prop] === '') {
      return true
    }
  }
}


let viewAll = (req, res) => {
  memeService
    .getAll()
    .then(data => {
      data = data
        .sort((a, b) => b.dateStamp - a.dateStamp)
        .filter(meme => meme.privacy === 'on')

      res.render('meme/viewAll', { data: data })
    })
}

let viewAddMeme = (req, res, status = null) => {
  let objFor = {}

  genreService
    .getAll()
    .then(genres => {
      if (!genres) {
        res.sendStatus(404)
        return
      }
      if (status === 'err') {
        res.render('meme/addMeme', {
          genres: genres,
          error: "Please fill all fields"
        })
        return
      }
      if (status === 'suc') {
        res.render('meme/addMeme', {
          genres: genres,
          success: "Movie Added"
        })
        return
      }

      res.render('meme/addMeme', { genres: genres })
    })
}

let getDetails = (req, res) => {
  let targetId = qs.parse(url.parse(req.url).query).id
  memeService
    .get(targetId)
    .then(targetedMeme => {
      res.render('meme/details', { targetedMeme: targetedMeme })
    })
}

let addMeme = (req, res) => {
  let fileName = shortid.generate() + '.jpg'
  let fields = req.body
  let files = req.files

  memeService
    .getAll()
    .then(allMemes => {
      let dirName = `/public/memeStorage/${Math.ceil(allMemes.length / 10)}`
      let relativeFilePath = dirName + '/' + fileName
      let absoluteDirPath = path.join(__dirname, `../${dirName}`)
      let absoluteFilePath = absoluteDirPath + '/' + fileName

      fs.access(absoluteDirPath, err => {
        if (err) {
          fs.mkdirSync(absoluteDirPath)
        }
        if (files.meme === undefined) {
          viewAddMeme(req, res, 'err')
          return
        }

        files.meme.mv(absoluteFilePath, err => {
          if (err) {
            console.log(err)
            viewAddMeme(req, res, 'err')
            return
          }

          if (fieldChecker(fields)) {
            viewAddMeme(req, res, 'err')
          } else {
            let memeForImport = memeGenerator(
              fields.memeTitle,
              relativeFilePath,
              fields.memeDescription,
              fields.status,
              fields.genreSelect
            )

            memeService
              .create(memeForImport)
              .then(() => {
                viewAddMeme(req, res, 'suc')
              })
              .catch(() => {
                viewAddMeme(req, res, 'err')
              })
          }
        })
      })
    })
}

let createGenreView = (req, res, status = null) => {
  if (status === 'err') {
    res.render('meme/addGenre', { error: "Please fill all fields" })
    return
  }
  if (status === 'suc') {
    res.render('meme/addGenre', { success: "Genre Added" })
    return
  }
  res.render('meme/addGenre')
}

let addGenre = (req, res) => {
  let fields = req.body

  if (fieldChecker(fields)) {
    createGenreView(req, res, 'err')
  } else {
    let genreObj = {
      title: fields.memeTitle,
      memes: []
    }

    genreService
      .create(genreObj)
      .then(() => {
        createGenreView(req, res, 'suc')
      })
      .catch(() => {
        createGenreView(req, res, 'err')
      })
  }
}

router
  .get('/viewAllMemes', (req, res) => viewAll(req, res))
  .get('/addMeme', (req, res) => viewAddMeme(req, res))
  .post('/addMeme', (req, res) => addMeme(req, res))
  .get('/getDetails', (req, res) => getDetails(req, res))
  .get('/addGenre', (req, res) => createGenreView(req, res))
  .post('/addGenre', (req, res) => addGenre(req, res))

module.exports = router