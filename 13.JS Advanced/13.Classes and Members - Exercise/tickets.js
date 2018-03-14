function tickets(arrTickets, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination
            this.price = price
            this.status = status
        }
    }

    let outPut = []

    for (let ticket of arrTickets) {
        let tokens = ticket
            .split('|')
        let currentObj = new Ticket(tokens[0], Number(tokens[1]), tokens[2])

        outPut.push(currentObj)
    }

    switch (criteria) {
        case 'destination':
            outPut.sort((a, b) => a.destination.localeCompare(b.destination))
            break
        case 'price':
            outPut.sort((a, b) => a.price - b.price)
            break
        case 'status':
            outPut.sort((a, b) => a.status.localeCompare(b.status))
            break
        default:
            outPut.sort()
            break
    }

    return outPut
}

console.log(tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
))