function search() {
    let text = $('#searchText').val()
    let countMatch = 0
    $("#towns li").each((index, item) => {
        if (item.textContent.includes(text)) {
            $(item).css("font-weight", "bold")
            countMatch++
        } else
            $(item).css("font-weight", "")
    })
    $('#result').text(`${countMatch} matches found.`)
}