function filterByAge(minage,firstName,firstAge,secondName,secondAge) {
    let minimumAge = minage

    let firstPerson = {
        name: firstName,
        age: firstAge
    }

    let secondPerson = {
        name: secondName,
        age: secondAge
    }
    if (firstPerson.age >= minimumAge) {
        console.log(firstPerson)
    }
    if (secondPerson.age >= minimumAge) {
        console.log(secondPerson)
    }
}

filterByAge(12, 'Ivan', 15, 'Asen', 9)