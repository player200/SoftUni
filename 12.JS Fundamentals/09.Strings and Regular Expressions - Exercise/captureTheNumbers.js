function captureTheNumbers(arrText) {
    let pattern = /[0-9]+/g
    let match = arrText.join(' ').match(pattern)
    console.log(match.join(' '))
}

captureTheNumbers(['The300',
    'What is that?',
    'I think it’s the 3rd movie.',
    'Lets watch it at 22:45'
])