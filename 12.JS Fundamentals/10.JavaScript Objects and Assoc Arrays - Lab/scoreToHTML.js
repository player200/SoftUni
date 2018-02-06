function scoreToHTML(objs) {
    let items = JSON.parse(objs)
    let str = '<table>\n'
    str += '  <tr><th>name</th><th>score</th></tr>\n'
    for (let key of items) {
        str+=`  <tr><td>${htmlEscape(key.name)}</td><td>${Number(key.score)}</td></tr>\n`
    }

    str += '</table>'
    console.log(str)

    function htmlEscape(strArr) {
        let map = {
            '"': '&quot;',
            '&': '&amp;',
            "'": '&#39;',
            '<': '&lt;',
            '>': '&gt;' };
        return strArr.replace(/["&'<>]/g, ch => map[ch]);
    }
}

scoreToHTML('[{"name":"Pesho","score":479}' +
    ',{"name":"Gosho","score":205}]')