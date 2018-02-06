function jsonsTable(arr) {
    let str = '<table>\n'
    for (let i = 0; i < arr.length; i++) {
        let currentObj=JSON.parse(arr[i])
        str += '\t<tr>\n'
        for (let key in currentObj) {
            str += `		<td>${currentObj[key]}</td>\n`
        }
        str += '\t<tr>\n'
    }
    str += '</table>'
    console.log(str)
}

jsonsTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'])