let isOddOrEven = require('../isOdd').isOddOrEven
let expect = require('chai').expect

describe("Is odd or even", function () {
    it("should return undefined for 1", function () {
        expect(isOddOrEven(1)).to.be.equal(undefined)
    })
    it("should return even for test", function () {
        expect(isOddOrEven('test')).to.be.equal('even')
    })
    it("should return odd for tes", function () {
        expect(isOddOrEven('tes')).to.be.equal('odd')
    })
})