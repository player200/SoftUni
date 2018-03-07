let lookupChar = require('../lookupChar').lookupChar
let expect = require('chai').expect

describe("Lookup Char", function () {
    it("should return undefined for (1,1)", function () {
        expect(lookupChar(1,1)).to.be.equal(undefined)
    })
    it("should return undefined for (test,test)", function () {
        expect(lookupChar('test','test')).to.be.equal(undefined)
    })
    it("should return undefined for (test,1.1)", function () {
        expect(lookupChar('test',1.1)).to.be.equal(undefined)
    })
    it("should return Incorrect index for (test,5)", function () {
        expect(lookupChar('test',5)).to.be.equal("Incorrect index")
    })
    it("should return Incorrect index for (test,4)", function () {
        expect(lookupChar('test',4)).to.be.equal("Incorrect index")
    })
    it("should return Incorrect index for (test,-4)", function () {
        expect(lookupChar('test',-4)).to.be.equal("Incorrect index")
    })
    it("should return e for (test,1)", function () {
        expect(lookupChar('test',1)).to.be.equal('e')
    })
})