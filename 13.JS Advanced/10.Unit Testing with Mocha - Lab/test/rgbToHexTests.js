let rgbToHexColor = require('../rgbToHex.js').rgbToHexColor
let expect = require('chai').expect

describe("RGB to hex", function () {
    it("should return #000000 for (0, 0, 0)", function () {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000')
    })
    it("should return undefined for (-1, 0, 0)", function () {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined
    })
    it("should return undefined for (0, -1, 0)", function () {
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined
    })
    it("should return undefined for (0, 0, -1)", function () {
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined
    })
    it("should return undefined for (test, 0, 0)", function () {
        expect(rgbToHexColor('test', 0, 0)).to.be.undefined
    })
    it("should return undefined for (0, test, 0)", function () {
        expect(rgbToHexColor(0, 'test', 0)).to.be.undefined
    })
    it("should return undefined for (0, 0, test)", function () {
        expect(rgbToHexColor(0, 0, 'test')).to.be.undefined
    })
    it("should return undefined for (256, 0, 0)", function () {
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined
    })
    it("should return undefined for (0, 256, 0)", function () {
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined
    })
    it("should return undefined for (0, 0, 256)", function () {
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined
    })
    it("should return #0C0D0E for (12, 13, 14)", function () {
        expect(rgbToHexColor(12, 13, 14)).to.be.equal('#0C0D0E')
    })
    it("should return #0C0D0E for (0, 105, 255)", function () {
        expect(rgbToHexColor(0, 105, 255)).to.be.equal('#0069FF')
    })
})