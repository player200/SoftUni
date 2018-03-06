let createCalculator = require('../addOrSubtract').createCalculator
let expect = require('chai').expect

describe("Add or subtract", function () {
    let calc

    beforeEach(function() {
        calc = createCalculator()
    })
    it("should return 5 for {add:2,add:3}", function () {
        calc.add(2)
        calc.add(3)
        expect(calc.get()).to.be.equal(5)
    })
    it("should return 2 for {add:2}", function () {
        calc.add(2)
        expect(calc.get()).to.be.equal(2)
    })
    it("should return 0 for {}", function () {
        expect(calc.get()).to.be.equal(0)
    })
    it("should return -2 for {add:-2}", function () {
        calc.add(-2)
        expect(calc.get()).to.be.equal(-2)
    })
    it("should return 1 for {add:-2,add:3}", function () {
        calc.add(-2)
        calc.add(3)
        expect(calc.get()).to.be.equal(1)
    })
    it("should return -1 for {add:-2,add:3,subtract:2}", function () {
        calc.add(-2)
        calc.add(3)
        calc.subtract(2)
        expect(calc.get()).to.be.equal(-1)
    })
    it("should return -2 for {subtract:2}", function () {
        calc.subtract(2)
        expect(calc.get()).to.be.equal(-2)
    })
    it("should return 1 for {subtract:2,subtract:-3}", function () {
        calc.subtract(2)
        calc.subtract(-3)
        expect(calc.get()).to.be.equal(1)
    })
    it("should return -1 for {add:-2,add:3,subtract:-2}", function () {
        calc.add(-2)
        calc.add(3)
        calc.subtract(-2)
        expect(calc.get()).to.be.equal(3)
    })
    it("should return NaN for {add:2,add:'test'}", function () {
        calc.add(2)
        calc.add('test')
        expect(calc.get()).to.be.NaN
    })
    it("should return NaN for {subtract:2,subtract:'test'}", function () {
        calc.subtract(2)
        calc.subtract('test')
        expect(calc.get()).to.be.NaN
    })
    it("should return NaN for {add:2,add:'test',subtract:2,subtract:'test'}", function () {
        calc.add(2)
        calc.add('test')
        calc.subtract(2)
        calc.subtract('test')
        expect(calc.get()).to.be.NaN
    })
    it("should return typeof calc for calc", function () {
        expect(typeof calc).to.be.equal('object')
    })
    it("should return 1.1 for {add:2.2,subtract:1.1}", function () {
        calc.add(2.2)
        calc.subtract(1.1)
        expect(calc.get()).to.be.equal(1.1)
    })
    it("should return 2 for {add:10,subtract:'7',add:'-2',subtract(-1)}", function () {
        calc.add(10)
        calc.subtract('7')
        calc.add('-2')
        calc.subtract(-1)
        expect(calc.get()).to.be.equal(2)
    })
})