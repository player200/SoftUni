let expect = require('chai').expect
const createList = require('../list-add-swap-shift-left-right')

describe('StringTests Unit Tests', function () {
    let myCreateList
    beforeEach(function () {
        myCreateList = createList()
    })
    it('should have prop when initial', function () {
        expect(myCreateList.hasOwnProperty('add')).to.be.true
        expect(myCreateList.hasOwnProperty('shiftLeft')).to.be.true
        expect(myCreateList.hasOwnProperty('shiftRight')).to.be.true
        expect(myCreateList.hasOwnProperty('swap')).to.be.true
        expect(myCreateList.hasOwnProperty('toString')).to.be.true
    });
    it('add should add any element', function () {
        myCreateList.add('test')
        myCreateList.add(4)
        expect(myCreateList.toString()).to.be.equal('test, 4')
    })
    it('shiftLeft should work correctly', function () {
        myCreateList.add('test')
        myCreateList.shiftLeft()
        expect(myCreateList.toString()).to.be.equal('test')
    })
    it('shiftLeft should work correctly', function () {
        myCreateList.add('test')
        myCreateList.add(3)
        myCreateList.add(4)
        myCreateList.shiftLeft()
        expect(myCreateList.toString()).to.be.equal('3, 4, test')
    })
    it('shiftRight should work correctly', function () {
        myCreateList.add('test')
        myCreateList.shiftRight()
        expect(myCreateList.toString()).to.be.equal('test')
    })
    it('shiftRight should work correctly', function () {
        myCreateList.add('test')
        myCreateList.add(3)
        myCreateList.add(4)
        myCreateList.shiftRight()
        expect(myCreateList.toString()).to.be.equal('4, test, 3')
    })
    it('swap should return false', function () {
        myCreateList.add('test')
        myCreateList.add(3)
        myCreateList.add(4)
        expect(myCreateList.swap('test', 1)).to.be.false
        expect(myCreateList.swap(1, 'test')).to.be.false
        expect(myCreateList.swap(1, -2)).to.be.false
        expect(myCreateList.swap(-1, 1)).to.be.false
        expect(myCreateList.swap(1, 1)).to.be.false
        expect(myCreateList.swap(3, 1)).to.be.false
        expect(myCreateList.swap(1, 3)).to.be.false
        expect(myCreateList.toString()).to.be.equal('test, 3, 4')
    })
    it('swap should return true', function () {
        myCreateList.add('test')
        myCreateList.add(3)
        myCreateList.add(4)
        expect(myCreateList.swap(0, 2)).to.be.true
        expect(myCreateList.toString()).to.be.equal('4, 3, test')
    })
    it('swap should return true', function () {
        myCreateList.add('test')
        myCreateList.add(3)
        myCreateList.add(4)
        expect(myCreateList.swap(2, 0)).to.be.true
        expect(myCreateList.toString()).to.be.equal('4, 3, test')
    })
})