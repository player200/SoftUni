function nextDay(year, month, day) {
    let date = new Date(year, month-1, day)
    let oneDay = 24 * 60 * 60 * 1000
    let newDate = new Date(date.getTime() + oneDay)

    return newDate.getFullYear()+'-'+(newDate.getMonth()+1)+'-'+newDate.getDate()
}

console.log(nextDay(2016, 9, 30))