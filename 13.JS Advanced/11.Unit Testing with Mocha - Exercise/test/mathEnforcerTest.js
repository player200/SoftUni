let mathEnforcer = require('../mathEnforcer').mathEnforcer
let expect = require('chai').expect

describe("Math Enforcer", function () {
    it("should return undefined for addFive(test)", function () {
        expect(mathEnforcer.addFive('test')).to.be.equal(undefined)
    })
    it("should return 6.2 for addFive(1.2)", function () {
        expect(mathEnforcer.addFive(1.2)).to.be.equal(6.2)
    })
    it("should return 7 for addFive(2)", function () {
        expect(mathEnforcer.addFive(2)).to.be.equal(7)
    })
    it("should return -1 for addFive(-6)", function () {
        expect(mathEnforcer.addFive(-6)).to.be.equal(-1)
    })
    it("should return undefined for subtractTen(test)", function () {
        expect(mathEnforcer.subtractTen('test')).to.be.equal(undefined)
    })
    it("should return 0 for subtractTen(10)", function () {
        expect(mathEnforcer.subtractTen(10)).to.be.equal(0)
    })
    it("should return 1 for subtractTen(11)", function () {
        expect(mathEnforcer.subtractTen(11)).to.be.equal(1)
    })
    it("should return 1.1 for subtractTen(11.1)", function () {
        expect(mathEnforcer.subtractTen(11.1)).to.be.closeTo(1.1, 0.01)
    })
    it("should return -11 for subtractTen(-1)", function () {
        expect(mathEnforcer.subtractTen(-1)).to.be.equal(-11)
    })
    it("should return undefined for sum(test,1)", function () {
        expect(mathEnforcer.sum('test',1)).to.be.equal(undefined)
    })
    it("should return undefined for sum(1,test)", function () {
        expect(mathEnforcer.sum(1,'test')).to.be.equal(undefined)
    })
    it("should return 2 for sum(1,1)", function () {
        expect(mathEnforcer.sum(1,1)).to.be.equal(2)
    })
    it("should return 2.2 for sum(1.1,1.1)", function () {
        expect(mathEnforcer.sum(1.1,1.1)).to.be.equal(2.2)
    })
})