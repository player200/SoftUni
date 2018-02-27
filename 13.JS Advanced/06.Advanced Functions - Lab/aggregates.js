function aggregates(arr) {
    let sum=arr.reduce((a,b)=>Number(a)+Number(b))
    let min=arr.reduce((a,b)=>Math.min(a, b))
    let max=arr.reduce((a,b)=>Math.max(a, b))
    let multiply=arr.reduce((a,b)=>Number(a)*Number(b))
    let concated=arr.join('')
    console.log(`Sum = ${sum}`)
    console.log(`Min = ${min}`)
    console.log(`Max = ${max}`)
    console.log(`Product = ${multiply}`)
    console.log(`Join = ${concated}`)
}

aggregates([2,3,10,5])