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

      let responseString = ''

      for (let meme of data) {
        responseString += `<div class="meme">
          <a href="/memes/getDetails?id=${meme.id}">
          <img class="memePoster" src="${meme.memeSrc}"/>          
          </div>`
      }

      fs.readFile('./views/viewAll.html', (err, html) => {
        if (err) {
          console.log(err)
          return
        }
        html = html
          .toString()
          .replace('<div id="replaceMe">{{replaceMe}}</div>', responseString)

        defaultResponse(html, res)
      })
    })
}

let viewAddMeme = (req, res, status = null) => {
  fs.readFile('./views/addMeme.html', (err, data) => {
    if (err) {
      console.log(err)
      return
    }
    genreService
      .getAll()
      .then(genres => {
        let exitString = ''

        for (let genre of genres) {
          exitString += `<option value="${genre._id}">${genre.title}</option>`
        }

        if (status === 'err') {
          data = data
            .toString()
            .replace(
              '<div id="replaceMe">{{replaceMe}}</div>',
              '<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>'
            )
        }
        if (status === 'suc') {
          data = data
            .toString()
            .replace(
              '<div id="replaceMe">{{replaceMe}}</div>',
              '<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>'
            )
        }
        defaultResponse(
          data
            .toString()
            .replace('<div id="replaceMe">{{replaceMe2}}</div>', exitString),
          res
        )
      })
  })
}

let getDetails = (req, res) => {
  let targetId = qs.parse(url.parse(req.url).query).id
  memeService
    .get(targetId)
    .then(targetedMeme => {
      let replaceString = `<div class="content">
      <img src="${targetedMeme.memeSrc}" alt=""/>
       <h3>Title  ${targetedMeme.title}</h3>
       <p> ${targetedMeme.description}</p>
      <button><a href="${targetedMeme.posterSrc}" download="${targetedMeme.title}.jpg" >Download Meme</a></button>
      </div>`

      fs.readFile('./views/details.html', (err, data) => {
        if (err) {
          console.log(err)
          return
        }
        data = data
          .toString()
          .replace('<div id="replaceMe">{{replaceMe}}</div>', replaceString)
        defaultResponse(data, res)
      })
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
  fs.readFile('./views/addGenre.html', (err, data) => {
    if (err) {
      console.log(err)
    }

    if (status === 'err') {
      data = data
        .toString()
        .replace(
          '<div id="replaceMe">{{replaceMe}}</div>',
          '<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>'
        )
    }
    if (status === 'suc') {
      data = data
        .toString()
        .replace(
          '<div id="replaceMe">{{replaceMe}}</div>',
          '<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>'
        )
    }
    defaultResponse(data, res)
  })
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