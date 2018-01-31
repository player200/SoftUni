function usernames(arr) {
    let usernames = []
    for (let i = 0; i < arr.length; i++) {
        let name = arr[i].substr(0, arr[i].indexOf('@')) + '.'
        let items = arr[i].substr(arr[i].indexOf('@') + 1)
        let tokens = items.split('.')

        for (let j = 0; j < tokens.length; j++) {
            name = name + tokens[j][0]
        }

        usernames.push(name)
    }

    console.log(usernames.join(', '))
}

usernames(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com'])