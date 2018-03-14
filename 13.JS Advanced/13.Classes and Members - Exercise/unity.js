class Rat {
    constructor(name) {
        this.name = name
        this.united=[]
    }

    unite(newObj){
        if (newObj instanceof Rat) {
            this.united.push(newObj);
        }
    }

    getRats(){
        return this.united
    }

    toString(){
        if (this.united.length === 0) {
            return this.name
        }

        let outPut = this.name + '\n'
        for (let currentRat of this.united) {
            outPut += '##' + currentRat.name + '\n'
        }

        return outPut
    }
}

let test = new Rat("Pesho")
console.log(test.toString())
console.log(test.getRats())
test.unite(new Rat("Gosho"))
test.unite(new Rat("Sasho"))
console.log(test.toString())