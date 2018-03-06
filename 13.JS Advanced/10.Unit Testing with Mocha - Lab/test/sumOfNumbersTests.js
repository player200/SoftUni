let sum = require('../sumNumbers.js').sum
let expect = require('chai').expect

describe("sum(arr) - sum array of numbers", function () {
    it("should return 3 for [1, 2]", function () {
        expect(sum([1, 2])).to.be.equal(3)
    })
    it("should return 1 for [1]", function () {
        expect(sum([1])).to.be.equal(1)
    })
    it("should return 0 for empty array", function () {
        expect(sum([])).to.be.equal(0)
    })
})