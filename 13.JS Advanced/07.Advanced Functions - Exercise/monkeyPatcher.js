function monkeyPatcher (command) {
    let obj = this
    let actions = (() => {
        function upvote() {
            obj.upvotes++
        }

        function downvote() {
            obj.downvotes++
        }

        function score() {
            let rating=''

            if (obj.upvotes + obj.downvotes < 10) {
                rating = 'new'
            }
            else if (obj.upvotes / (obj.upvotes + obj.downvotes) > 0.66) {
                rating = 'hot'
            }
            else if ((obj.upvotes > 100 || obj.downvotes > 100)
                && obj.upvotes >= obj.downvotes) {
                rating = 'controversial'
            }
            else if (obj.downvotes > obj.upvotes) {
                rating = 'unpopular'
            }
            else {
                rating = 'new'
            }


            if (obj.upvotes + obj.downvotes > 50) {
                let votesToAdd = Math.ceil(0.25 * Math.max(obj.upvotes, obj.downvotes))
                return [obj.upvotes + votesToAdd, obj.downvotes + votesToAdd, obj.upvotes - obj.downvotes, rating]
            }
            else {
                return [obj.upvotes, obj.downvotes, obj.upvotes - obj.downvotes, rating]
            }
        }

        return {
            upvote,
            downvote,
            score
        }
    })()
    return actions[command]()
}