function loadCommits() {
    $("#commits").empty()
    let username = $('#username').val()
    let repository = $('#repo').val()

    let url = `https://api.github.com/repos/${username}/${repository}/commits`

    $.ajax(url)
        .then(function (commits) {
            for (let commit of commits)
                $("#commits")
                    .append($("<li>")
                        .text(commit.commit.author.name
                            + ": "
                            + commit.commit.message))
        })
        .catch(function (err) {
            $("#commits")
                .append($("<li>")
                    .text("Error: "
                        + err.status
                        + ' ('
                        + err.statusText
                        + ')'))
        })
}