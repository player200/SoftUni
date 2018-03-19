class PaymentProcessor {
    constructor(options) {
        this.idCollector = []
        this.collector = []
        this.options = options
    }

    get options() {
        return this._options
    }

    set options(value) {
        if (value === undefined) {
            this._options= {
                types: ["service", "product", "other"],
                precision: 2
            }
        }
        else {
            let obj = {}
            if (value.hasOwnProperty('types')) {
                obj.types = value.types
            }
            else {
                obj.types = ["service", "product", "other"]
            }
            if (value.hasOwnProperty('precision')) {
                obj.precision = value.precision
            }
            else {
                obj.precision = 2
            }
            this._options = obj
        }
    }

    registerPayment(id, name, type, value) {
        this._validate(id, name, type, value)
        value = value.toFixed(this.options.precision)
        let currentObj = {
            id: id,
            name: name,
            type: type,
            value: value
        }
        this.collector.push(currentObj)
        this.idCollector.push(id)
    }

    deletePayment(id) {
        if (!this.idCollector.includes(id)) {
            throw new Error('ID not found')
        }

        for (let i = 0; i < this.collector.length; i++) {
            if (this.collector[i].id === id) {
                let index = this.collector.indexOf(this.collector[i])
                this.collector.splice(index, 1)

                let indexSecond = this.idCollector.indexOf(id)
                this.idCollector.splice(indexSecond, 1)
                break
            }
        }
    }

    get(id) {
        if (!this.idCollector.includes(id)) {
            throw new Error('ID not found')
        }

        let outPut = ''
        for (let i = 0; i < this.collector.length; i++) {
            let currentObj = this.collector[i]
            if (currentObj.id === id) {
                outPut = `Details about payment ID: ${currentObj.id}\n`
                outPut += `- Name: ${currentObj.name}\n`
                outPut += `- Type: ${currentObj.type}\n`
                outPut += `- Value: ${currentObj.value}`
                break
            }
        }

        return outPut
    }

    setOptions(options) {
        let obj = {}
        if (options.hasOwnProperty('types')) {
            obj.types = options.types
        }
        else {
            obj.types = ["service", "product", "other"]
        }
        if (options.hasOwnProperty('precision')) {
            obj.precision = options.precision
        }
        else {
            obj.precision = 2
        }
        this.options = obj
    }

    toString() {
        let countOfPayment = this.collector.length
        let payment = 0
        if (countOfPayment !== 0) {
            for (let obj of this.collector) {
                payment += Number(obj.value)
            }
        }
        let output = 'Summary:\n'
        output += `- Payments: ${countOfPayment}\n`
        output += `- Balance: ${payment.toFixed(this.options.precision)}`
        return output
    }

    _validate(id, name, type, value) {
        if (id === ''
            || name === ''
            || Number(value) === NaN) {
            throw new Error('invalid type')
        }
        if(this.collector.length!==0){
            for (let obj of this.collector) {
                if (obj.id === id) {
                    throw new Error('invalid type')
                }
            }
        }

        if (!this.options.types.includes(type)) {
            throw new Error('invalid type')
        }
    }
}

const generalPayments = new PaymentProcessor();
generalPayments.registerPayment('0001', 'Microchips', 'product', 15000);
generalPayments.registerPayment('01A3', 'Biopolymer', 'product', 23000);
console.log(generalPayments.toString());
//// Should throw an error (invalid type)
////generalPayments.registerPayment('E028', 'Rare-earth elements', 'materials', 8000);
generalPayments.setOptions({types: ['product', 'material']});
generalPayments.registerPayment('E028', 'Rare-earth elements', 'material', 8000);
console.log(generalPayments.get('E028'));
generalPayments.registerPayment('CF15', 'Enzymes', 'material', 55000);
////// Should throw an error (ID not found)
////generalPayments.deletePayment('E027');
////// Should throw an error (ID not found)
////generalPayments.get('E027');
generalPayments.deletePayment('E028');
console.log(generalPayments.toString());
//// Initialize processor with custom types
const servicePyaments = new PaymentProcessor({types: ['service']});
servicePyaments.registerPayment('01', 'HR Consultation', 'service', 3000);
servicePyaments.registerPayment('02', 'Discount', 'service', -1500);
console.log(servicePyaments.toString());
//// Initialize processor with custom precision
//const transactionLog = new PaymentProcessor({precision: 5});
//transactionLog.registerPayment('b5af2d02-327e-4cbf', 'Interest', 'other', 0.00153);
//console.log(transactionLog.toString());