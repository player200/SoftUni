function escaping(arr) {
    return "<ul>\n" +
        arr.map(htmlEscape)
            .map(arr => ` <li>${arr}</li>`)
            .join("\n") +
        "\n" +
        "</ul>\n"

    function htmlEscape(arr) {
        let map = {
            '"': '&quot;',
            '&': '&amp;',
            "'": '&#39;',
            '<': '&lt;',
            '>': '&gt;'
        }

        return arr.replace(/[\"&'<>]/g, ch => map[ch])
    }
}

console.log(escaping(['<div style=\"color: red;\">Hello, Red!</div>',
    '<table><tr><td>Cell 1</td><td>Cell 2</td><tr>']))
