function multiplicationTable(number) {
    let result = '<table border="1">\n';
    result += "  <tr><th>x</th>"

    for (let r = 1; r <= number; r++) {
        result += `<th>${r}</th>`
    }

    result += `</tr>\n`

    for (let r = 1; r <= number; r++) {
        result += `  <tr><th>${r}</th>`;
        for (let c = 1; c <= number; c++) {
            result += `<td>${r*c}</td>`;
        }
        result += `</tr>\n`
    }

    result += '</table>'
    console.log(result)
}

multiplicationTable(5)