function JSONToHTMLTable(strObj) {
    let objCollector = JSON.parse(strObj)
    let str = '<table>\n'
    str += '  <tr>'
    for (let key of Object.keys(objCollector[0])) {
        str += `<th>${htmlEscape(key)}</th>`
    }
    str+='</tr>\n'

    for (let items of objCollector) {
        str+='  <tr>'
        for (let value in items) {
            let test = Number(items[value]);
            if (isNaN(test)) {
                str += `<td>${htmlEscape(items[value])}</td>`
            }
            else {
                str += `<td>${test}</td>`
            }

        }
        str+='</tr>\n'
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

JSONToHTMLTable('[{"Name":"Tomatoes & Chips","Price":2.35},' +
    '{"Name":"J&B Chocolate","Price":0.96}]')