function restaurantBill(arr) {
    let price = 0
    let products = []
    for (let i = 0; i < arr.length; i += 2) {
        products.push(arr[i])
        price += Number(arr[i + 1])
    }

    console.log(`You purchased ${products.join(', ')} for a total sum of ${price}`)
}

restaurantBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80', 'Lasagna', '5.69'])