function timer() {
    let startBtn = $('#start-timer')
    let pauseBtn = $('#stop-timer')
    let hours=$('#hours')
    let minutes=$('#minutes')
    let seconds=$('#seconds')

    let isStarted=false
    let currentHours=0
    let currentMinutes=0
    let currentSeconds=0
    let timer
    let tempSeconds = 0
    let allTimeHours = 0

    $(startBtn).on('click',function () {
        if (!isStarted) {
            isStarted = true
            timer = setInterval(tick, 1000)
        }
    })

    $(pauseBtn).on('click',function () {
        clearInterval(timer)
        isStarted = false
    })

    function tick() {
        tempSeconds++
        currentHours = allTimeHours
        currentMinutes = Math.floor(tempSeconds / 60)
        currentSeconds = tempSeconds % 60

        if (currentMinutes >= 60) {
            currentMinutes = 0
            tempSeconds = 0
            allTimeHours++
        }

        if (currentHours < 10) {
            currentHours = '0' + currentHours
        }
        if (currentMinutes < 10) {
            currentMinutes = '0' + currentMinutes
        }
        if (currentSeconds < 10) {
            currentSeconds = '0' + currentSeconds
        }

        hours.text(currentHours)
        minutes.text(currentMinutes)
        seconds.text(currentSeconds)
    }
}