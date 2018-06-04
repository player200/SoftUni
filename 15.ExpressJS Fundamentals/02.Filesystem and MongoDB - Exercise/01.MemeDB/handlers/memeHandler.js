const fs = require('fs')
const path = require('path');
const formidable = require('formidable')
const shortid = require('shortid')
const database = require('../config/dataBase')

module.exports = (req, res) => {
  if (req.pathname === '/viewAllMemes' && req.method === 'GET') {
    fs.readFile('./views/viewAll.html', 'utf8', (err, data) => {
      if (err) {
        console.log(err)
        return
      }
      let test = database.getDb()

      test.sort(function (a, b) {
        return a.dateStamp - b.dateStamp;
      })

      test = test.filter(x => x['privacy'] !== undefined)

      let html = ''
      for (let meme of test) {
        let pattern =
          `<div class="meme">
             <a href="/getDetails?id=${meme.id}">
             <img class="memePoster" src="${meme.memeSrc}"/>  
             </a>        
          </div>`
        html += pattern + ' '
      }

      let patternToReplace = '<div id="replaceMe">{{replaceMe}}</div>'
      data = data.replace(patternToReplace, html)

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(data)
      res.end()
    })
  } else if (req.pathname === '/addMeme' && req.method === 'GET') {
    fs.readFile('./views/addMeme.html', 'utf8', (err, data) => {
      if (err) {
        console.log(err)
        return
      }
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.end(data)
    })
  } else if (req.pathname === '/addMeme' && req.method === 'POST') {
    var form = new formidable.IncomingForm(),
      files = [],
      fields = {}

    let currentFolder = 0

    let test = fs.readdirSync(`./public/memeStorage/${currentFolder}/`)
    while (test.length > 999) {
      currentFolder++
      if (!fs.existsSync(`./public/memeStorage/${currentFolder}`)) {
        fs.mkdirSync(`./public/memeStorage/${currentFolder}`)
      }
      test = fs.readdirSync(`./public/memeStorage/${currentFolder}/`)
    }

    let filePath = `/public/memeStorage/${currentFolder}/`
    form.uploadDir = path.normalize(path.join(__dirname, `..${filePath}`))

    form
      .on('field', (field, value) => {
        fields[field] = value
      })
      .on('fileBegin', (name, file) => {
        let fileName = `${shortid.generate()}.${file.name.split('.')[1]}`
        fields['id'] = shortid.generate()
        fields['dateStamp'] = Date.now()
        fields['memeSrc'] = `${filePath}${fileName}`
        file.path = `${form.uploadDir}/${fileName}`
      })
      .on('file', (field, file) => {
        files.push([field, file])
      })
      .on('end', () => {
        database.add(fields)
        database.save().then(() => {
          res.writeHead(302, {
            Location: '/'
          })

          res.end()
        })
      })

    form.parse(req)
  } else if (req.pathname.startsWith('/getDetails') && req.method === 'GET') {
    let id = req.url.substr(req.url.lastIndexOf('=') + 1)
    fs.readFile('./views/details.html', 'utf8', (err, data) => {
      if (err) {
        console.log(err)
        return
      }
      let meme = database.getDb()
        .filter(x => x.id === id)[0]

      let template =
        `<div class="content">
          <img src="${meme.memeSrc}" alt=""/>
          <h3>Title  ${meme.title}</h3>
          <p> ${meme.description}</p>
          <button><a href="${meme.memeSrc}" download>Download Meme</a></button>
        </div>`


      let patternToReplace = '<div id="replaceMe">{{replaceMe}}</div>'
      data = data.replace(patternToReplace, template)

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })

      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}