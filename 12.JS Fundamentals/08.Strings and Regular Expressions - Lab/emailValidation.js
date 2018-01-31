function emailValidation(email) {
    let regex=/^[a-zA-Z0-9]+@[a-z]+(\.[a-z]+)+$/g

    if(regex.test(email)){
        console.log('Valid')
    }
    else {
        console.log('Invalid')
    }
}

emailValidation('valid@emai1l.bg')