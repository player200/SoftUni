function formFiller(username, email, phoneNumber, arr) {
    let regexUsername = /<![a-zA-Z]+!>/g
    let regexEmail = /<@[a-zA-Z]+@>/g
    let regexPhone = /<\+[a-zA-Z]+\+>/g

    arr.forEach(line => {
        line = line.replace(regexUsername, username)
        line = line.replace(regexEmail, email)
        line = line.replace(regexPhone, phoneNumber)
        console.log(line)
    })
}

formFiller('Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
)