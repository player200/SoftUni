function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color
            this.gasWeight = Number(gasWeight)
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight)
            this.ribbonColor = ribbonColor
            this.ribbonLength = Number(ribbonLength)
            this._ribbon = {
                color: ribbonColor,
                length: Number(ribbonLength)
            }
        }

        get ribbon() {
            return this._ribbon
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(ribbonColor, ribbonLength)
            this.text = text
            this._ribbon = {
                color: ribbonColor,
                length: Number(ribbonLength)
            }
        }

        get ribbon() {
            return this._ribbon
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}

let classes = solve()
let test = new classes.BirthdayBalloon("Tumno-bqlo", 20.5, "Svetlo-cherno", 10.25, "Happy Birthday!!!")
let ribbon = test.ribbon
console.log(ribbon.length)