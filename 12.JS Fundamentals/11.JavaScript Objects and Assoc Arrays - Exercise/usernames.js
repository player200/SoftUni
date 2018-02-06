function usernames(arr) {
    let uniqueUsernames=new Set()
    for (let name of arr) {
        uniqueUsernames.add(name);
    }

    uniqueUsernames = [...uniqueUsernames]
    sortArray(uniqueUsernames)

    console.log(uniqueUsernames.join('\n'))

    function sortArray(arr) {
        arr.sort(function (a, b) {
            return a.length !== b.length
                ? a.length - b.length
                : a.localeCompare(b)
        })

        return arr
    }
}

usernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston'])