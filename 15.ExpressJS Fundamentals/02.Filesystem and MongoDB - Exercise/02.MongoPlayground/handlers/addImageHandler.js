const url = require('url')
const fs = require('fs')
const qs = require('querystring')
const Image = require('../models/ImageSchema')
const ObjectId = require('mongoose').Types.ObjectId

module.exports = (req, res) => {
  if (req.pathname === '/addImage' && req.method === 'POST') {
    addImage(req, res)
  } else if (req.pathname === '/delete' && req.method === 'GET') {
    deleteImg(req, res)
  } else {
    return true
  }
}

function addImage(req, res) {
  let body = []
  req.on('data', (data) => {
    body.push(data)
  })
  req.on('end', () => {
    let dataString = Buffer
      .concat(body)
      .toString()

    let image = {}
    image = qs.parse(dataString)

    let tags = image.tagsID.split(',').reduce((p, c, i, a) => {
      if (p.includes(c) || c.length === 0) {
        return p
      } else {
        p.push(c)
        return p
      }
    }, []).map(ObjectId)
    let objImage = {
      url: image.imageUrl,
      description: image.description,
      creationdate:Date.now(),
      tags: tags
    }
    Image.create(objImage).then((image) => {
      res.writeHead(302, {
        location: '/'
      })

      res.end()
    }).catch((err) => {
      res.writeHead(404, {
        'Content-Type': 'text/plain'
      })

      console.log(err)
      res.write('404 not found!')
      res.end()
    })
  })
}

function deleteImg(req, res) {
  Image.deleteOne({ _id: req.pathquery.id }).then((image) => {
    res.writeHead(302, {
      location: '/'
    })

    res.end()
  }).catch((err) => {
    res.writeHead(404, {
      'Content-Type': 'text/plain'
    })

    console.log(err)
    res.write('404 not found!')
    res.end()
  })
}