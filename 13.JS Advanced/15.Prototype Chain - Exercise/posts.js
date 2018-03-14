function solve() {
    class Post {
        constructor(title, content) {
            this.title = title
            this.content = content
        }

        toString() {
            return `Post: ${this.title}` + '\n' + `Content: ${this.content}`
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content)
            this.likes = likes
            this.dislikes = dislikes
            this.comments = []
        }

        addComment(commend) {
            this.comments.push(commend)
        }

        toString() {
            let result = super.toString()+`\nRating: ${this.likes - this.dislikes}`
            if (this.comments.length > 0) {
                result += `\nComments:`
                for (let commend of this.comments) {
                    result += `\n * ${commend}`
                }
            }

            return result
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content)
            this.views = views
        }

        view() {
            this.views++
            return this
        }

        toString() {
            return super.toString()+`\nViews: ${this.views}`
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

let Post = solve().Post
let BlogPost = solve().BlogPost
let test = new BlogPost("TestTitle", "TestContent", 5)

test.view().view().view()

console.log(test.toString())
//let post = new Post("Post", "Content")
//console.log(post.toString())
// Post: Post
// Content: Content
//let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30)
//scm.addComment("Good post")
//scm.addComment("Very good post")
//scm.addComment("Wow!")
//console.log(scm.toString())
// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
