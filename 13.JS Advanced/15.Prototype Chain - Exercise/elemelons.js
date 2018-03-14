function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly')
            }
            this.weight = Number(weight)
            this.melonSort = melonSort
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort)
            this.elementIndex = this.weight * this.melonSort.length
        }

        toString() {
            return `Element: Water\n` +
                `Sort: ${this.melonSort}\n` +
                `Element Index: ${this.elementIndex}`
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort)
            this.elementIndex = this.weight * this.melonSort.length
        }

        toString() {
            return `Element: Fire\n` +
                `Sort: ${this.melonSort}\n` +
                `Element Index: ${this.elementIndex}`
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort)
            this.elementIndex = this.weight * this.melonSort.length
        }

        toString() {
            return `Element: Air\n` +
                `Sort: ${this.melonSort}\n` +
                `Element Index: ${this.elementIndex}`
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort)
            this.elementIndex = this.weight * this.melonSort.length
        }

        toString() {
            return `Element: Earth\n` +
                `Sort: ${this.melonSort}\n` +
                `Element Index: ${this.elementIndex}`
        }
    }

    class Melolemonmelon extends Watermelon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this.counter = 0;
            this.elements = [Watermelon, Firemelon, Earthmelon, Airmelon];
        }

        morph() {
            this.counter++;
            return this;
        }

        toString() {
            return new this.elements[this.counter % 4](this.weight, this.melonSort).toString()
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Airmelon,
        Earthmelon,
        Melolemonmelon
    }
}