function attachEvents() {
    $(document).ready(function () {
        // Fill appkey, username and password from your Kinvey project
        const kinveyAppId = ""
        const kinveyUsername = ""
        const kinveyPassword = ""
        const serviceUrl = "https://baas.kinvey.com/appdata/" + kinveyAppId
        const base64auth = btoa(kinveyUsername + ":" + kinveyPassword)
        const authHeaders = {"Authorization": "Basic " + base64auth}
        $("#btnLoadPosts").click(loadPostsClick)
        $("#btnViewPost").click(viewPostClick)

        function loadPostsClick() {
            $.ajax({
                url: serviceUrl + "/posts",
                headers: authHeaders
            })
                .then(function (posts) {
                    $("#posts").empty()
                    for (let post of posts) {
                        let option = $("<option>")
                            .text(post.title)
                            .val(post._id)
                        $("#posts").append(option)
                    }
                })
                .catch(function (err) {
                    let errorDiv = $("<div>").text("Error: "
                        + err.status
                        + ' ('
                        + err.statusText
                        + ')')
                    $(document.body).prepend(errorDiv)
                    setTimeout(function () {
                        $(errorDiv).fadeOut(function () {
                            $(errorDiv).remove()
                        })
                    }, 3000)
                })
        }

        function viewPostClick() {
            let selectedPostId = $("#posts").val()
            if (!selectedPostId) {
                return
            }

            let requestPosts = $.ajax({
                url: serviceUrl + "/posts/" + selectedPostId,
                headers: authHeaders
            })
            let requestComments = $.ajax({
                url: serviceUrl +
                `/comments/?query={"post_id":"${selectedPostId}"}`,
                headers: authHeaders
            })
            Promise.all([requestPosts, requestComments])
                .then(function ([post, comments]) {
                    $("#post-title").text(post.title)
                    $("#post-body").text(post.body)
                    $("#post-comments").empty()
                    for (let comment of comments) {
                        let commentItem = $("<li>")
                            .text(comment.text)
                        $("#post-comments")
                            .append(commentItem)
                    }
                })
                .catch(function (err) {
                    let errorDiv = $("<div>").text("Error: "
                        + err.status
                        + ' ('
                        + err.statusText
                        + ')')
                    $(document.body).prepend(errorDiv)
                    setTimeout(function () {
                        $(errorDiv).fadeOut(function () {
                            $(errorDiv).remove()
                        })
                    }, 3000)
                })
        }
    })
}