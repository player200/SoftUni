function employeeData(arr) {
    let regex = /^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9- ]+)\b$/

    for (let i = 0; i < arr.length; i++) {
        let match = regex.exec(arr[i])
        if(match){
            console.log(`Name: ${match[1]}`)
            console.log(`Position: ${match[3]}`)
            console.log(`Salary: ${match[2]} `)
        }
    }
}

employeeData(['Jonathan - 2000 - Manager',
    'Peter- 1000- Chuck',
    'George - 1000 - Team Leader'
])