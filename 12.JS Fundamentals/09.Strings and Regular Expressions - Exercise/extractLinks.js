function extractLinks(arr) {
    let pattern = /www\.[a-zA-Z0-9-]+(\.[a-z]+)+/g
    for (let text of arr) {
        let match = text.match(pattern)
        if (match) {
            console.log(match.join('\n'))
        }
    }
}

extractLinks(['Join WebStars now for free, at www.web-stars.com',
    'You can also support our partners:',
    'Internet - www.internet.com',
    'WebSpiders - www.webspiders101.com',
    'Sentinel - www.sentinel.-ko'])