let expect = require('chai').expect
let PaymentPackage = require('../PaymentPackage')

describe('Payment Unit Tests', function () {
    let myPayment
    beforeEach(function () {
        myPayment = new PaymentPackage('test', 3)
    })

    describe('Initial tests', function () {
        it('should have toString', function () {
            expect(PaymentPackage.prototype.hasOwnProperty('toString')).to.be.true
            expect(PaymentPackage.prototype.hasOwnProperty('name')).to.be.true
            expect(PaymentPackage.prototype.hasOwnProperty('value')).to.be.true
            expect(PaymentPackage.prototype.hasOwnProperty('VAT')).to.be.true
            expect(PaymentPackage.prototype.hasOwnProperty('active')).to.be.true
        })
        it('should have prop name', function () {
            expect(myPayment.name).to.be.equal('test')
            expect(myPayment.toString()).to.be.equal(`Package: ${myPayment.name}
- Value (excl. VAT): ${myPayment.value}
- Value (VAT ${myPayment.VAT}%): ${myPayment.value * (1 + myPayment.VAT / 100)}`)
        })
        it('should have prop value', function () {
            expect(myPayment.value).to.be.equal(3)
        })
        it('should have prop vat', function () {
            expect(myPayment.VAT).to.be.equal(20)
        })
        it('should have prop value', function () {
            expect(myPayment.active).to.be.true
        })

        //test throw
        it('should throw error', function () {
            expect(() => {
                new PaymentPackage('', 3)
            }).to.be.throw
        })
        it('should throw error', function () {
            expect(() => {
                new PaymentPackage(3, 3)
            }).to.be.throw
        })
        it('should throw error', function () {
            expect(() => {
                new PaymentPackage('test', 'test')
            }).to.throw
        })
        it('should throw error', function () {
            expect(() => {
                new PaymentPackage('test', -1)
            }).to.throw
        })
        it('should have prop vat', function () {
            expect(() => {
                myPayment.VAT('str')
            }).to.throw
        })
        it('should have prop vat', function () {
            expect(() => {
                myPayment.VAT(-1)
            }).to.throw
        })
        it('should have prop value', function () {
            expect(() => {
                myPayment.action('test')
            }).to.throw
        })
        //test 0 tests
        it('should have prop vat', function () {
            let test = new PaymentPackage('test', 0)
            expect(test.value).to.be.equal(0)
        })
        it('should have prop vat', function () {
            let test = new PaymentPackage('test', 0)
            expect(test.toString()).to.be.equal(`Package: ${test.name}
- Value (excl. VAT): ${test.value}
- Value (VAT ${test.VAT}%): ${test.value * (1 + test.VAT / 100)}`)
        })
        it('should have prop vat', function () {
            myPayment.VAT = 0
            expect(myPayment.VAT).to.be.equal(0)
        })
        it('should have prop vat', function () {
            myPayment.VAT = 0
            expect(myPayment.toString()).to.be.equal(`Package: ${myPayment.name}
- Value (excl. VAT): ${myPayment.value}
- Value (VAT ${myPayment.VAT}%): ${myPayment.value * (1 + myPayment.VAT / 100)}`)
        })
        it('should have prop value', function () {
            myPayment.active = false
            expect(myPayment.active).to.be.false
        })
        it('should have prop value', function () {
            myPayment.active=false
            expect(myPayment.toString()).to.be.equal(`Package: ${myPayment.name} (inactive)
- Value (excl. VAT): ${myPayment.value}
- Value (VAT ${myPayment.VAT}%): ${myPayment.value * (1 + myPayment.VAT / 100)}`)
        })
    })
})