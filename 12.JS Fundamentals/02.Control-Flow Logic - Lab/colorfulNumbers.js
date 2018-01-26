function colorfulNumbers(number) {
    console.log(`<ul>`)
    for (let i = 1; i <= number; i++) {
        if(i%2===0){
            console.log(`  <li><span style='color:blue'>${i}</span></li>`)
        }
        else{
            console.log(`  <li><span style='color:green'>${i}</span></li>`)
        }
    }
    console.log(`</ul>`)
}

colorfulNumbers(10)