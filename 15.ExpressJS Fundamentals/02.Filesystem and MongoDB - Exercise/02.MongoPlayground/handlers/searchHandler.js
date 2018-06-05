const fs = require('fs')
const Image = require('../models/ImageSchema')
const Tag = require('../models/TagSchema')

module.exports = (req, res) => {
  if (req.pathname === '/search') {
    fs.readFile('./views/results.html', 'utf8', (err, data) => {
      let html = ''

      let params = {}
      let limitNumber = null

      if (req.pathquery.afterDate && req.pathquery.beforeDate) {
        params.creationdate = { $gte: Date.parse(req.pathquery.afterDate), $lt: Date.parse(req.pathquery.beforeDate) }
      }
      if (req.pathquery.afterDate && !req.pathquery.beforeDate) {
        params.creationdate = { $gte: Date.parse(req.pathquery.afterDate) }
      }
      if (!req.pathquery.afterDate && req.pathquery.beforeDate) {
        params.creationdate = { $lt: Date.parse(req.pathquery.beforeDate) }
      }
      if (req.pathquery.Limit) {
        limitNumber = Number(req.pathquery.Limit)
      }

      let tags = []
      if (req.pathquery.tagName) {
        tags = req.pathquery.tagName.split(',').filter(x => x.length > 0)
      }
      if (tags.length > 0) {
        Tag.find({ name: { $in: tags } }).then(findedTags => {
          let tagsId = findedTags.map(m => m._id)
          params.tags = { $in: tagsId }
          getImagesAndResponce(params)
        }).catch(err => {
          res.writeHead(404, {
            'Content-Type': 'text/plain'
          })

          console.log(err)
          res.write('404 not found!')
          res.end()
        })
      } else {
        getImagesAndResponce(params)
      }

      function getImagesAndResponce(params) {
        Image.find(params).limit(limitNumber).then(images => {
          for (let image of images) {
            html += `<fieldset id =${image._id}>
          <img src="${image.url}">
          </img><p>${image.description}<p/>
          <button onclick='location.href="/delete?id=${image._id}"'class='deleteBtn'>Delete
          </button> 
          </fieldset>`
          }

          data = data
            .toString()
            .replace(`<div class="replaceMe"></div>`, html)

          res.write(data)
          res.end()
        }).catch(err => {
          res.writeHead(404, {
            'Content-Type': 'text/plain'
          })

          console.log(err)
          res.write('404 not found!')
          res.end()
        })
      }
    })
  } else {
    return true
  }
}

