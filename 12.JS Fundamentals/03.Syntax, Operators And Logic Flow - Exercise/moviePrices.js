function moviePrices(params) {
    let filmName = params[0].toLowerCase()
    let day = params[1].toLowerCase()
    let price = 0

    switch (day) {
        case 'monday':
            if (filmName === 'the godfather') {
                price = 12
            }
            else if (filmName === `schindler's list`) {
                price = 8.50
            }
            else if (filmName === `casablanca`) {
                price = 8
            }
            else if (filmName === `the wizard of oz`) {
                price = 10
            }
            else {
                price = 'error'
            }
            break
        case 'tuesday':
            if (filmName === 'the godfather') {
                price = 10
            }
            else if (filmName === `schindler's list`) {
                price = 8.50
            }
            else if (filmName === `casablanca`) {
                price = 8
            }
            else if (filmName === `the wizard of oz`) {
                price = 10
            }
            else {
                price = 'error'
            }
            break
        case 'wednesday':
            if (filmName === 'the godfather') {
                price = 15
            }
            else if (filmName === `schindler's list`) {
                price = 8.50
            }
            else if (filmName === `casablanca`) {
                price = 8
            }
            else if (filmName === `the wizard of oz`) {
                price = 10
            }
            else {
                price = 'error'
            }
            break
        case 'thursday':
            if (filmName === 'the godfather') {
                price = 12.5
            }
            else if (filmName === `schindler's list`) {
                price = 8.50
            }
            else if (filmName === `casablanca`) {
                price = 8
            }
            else if (filmName === `the wizard of oz`) {
                price = 10
            }
            else {
                price = 'error'
            }
            break
        case 'friday':
            if (filmName === 'the godfather') {
                price = 15
            }
            else if (filmName === `schindler's list`) {
                price = 8.50
            }
            else if (filmName === `casablanca`) {
                price = 8
            }
            else if (filmName === `the wizard of oz`) {
                price = 10
            }
            else {
                price = 'error'
            }
            break
        case 'saturday':
            if (filmName === 'the godfather') {
                price = 25
            }
            else if (filmName === `schindler's list`) {
                price = 15
            }
            else if (filmName === `casablanca`) {
                price = 10
            }
            else if (filmName === `the wizard of oz`) {
                price = 15
            }
            else {
                price = 'error'
            }
            break
        case 'sunday':
            if (filmName === 'the godfather') {
                price = 30
            }
            else if (filmName === `schindler's list`) {
                price = 15
            }
            else if (filmName === `casablanca`) {
                price = 10
            }
            else if (filmName === `the wizard of oz`) {
                price = 15
            }
            else {
                price = 'error'
            }
            break
        default:
            price = 'error'
    }

    console.log(price)
}

moviePrices(['The Godfather', 'Friday'])