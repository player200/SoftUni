function templateFormat(params) {
    let html=`<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n`
    for (let i = 0; i < params.length; i+=2) {
        html+=`  <question>
    ${params[i]}
  </question>
  <answer>
    ${params[i+1]}
  </answer>\n`
    }
    html+=`</quiz>`
    console.log(html)
}

templateFormat(
    ["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"])