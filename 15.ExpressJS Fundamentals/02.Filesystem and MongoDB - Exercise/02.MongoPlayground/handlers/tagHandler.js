const url = require('url')
const fs = require('fs')
const qs = require('querystring')
const Tag = require('../models/TagSchema')

module.exports = (req, res) => {
  if (req.pathname === '/generateTag' && req.method === 'POST') {
    let body = []
    req.on('data', (data) => {
      body.push(data)
    })
    req.on('end', () => {
      let dataString = Buffer
        .concat(body)
        .toString()

      let tag = {}
      tag = qs.parse(dataString)

      tag['name'] = tag.tagName
      delete tag.tagName
      tag['images'] = []
      tag['creationdate'] = Date.now()

      Tag.create(tag).then((newTag) => {
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
  } else {
    return true
  }
}
