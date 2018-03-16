let expect = require('chai').expect
let Sumator = require('../sumator')

describe('Sumator Unit Tests', function () {
    let mySumator
    beforeEach(function () {
        mySumator = new Sumator()
    })

    describe('Initial tests', function () {
        it('add is attached to proto', function () {
            expect(Sumator.prototype.hasOwnProperty('add')).to.be.true
        })
        it('sumNums is attached to proto', function () {
            expect(Sumator.prototype.hasOwnProperty('sumNums')).to.be.true
        })
        it('removeByFilter is attached to proto', function () {
            expect(Sumator.prototype.hasOwnProperty('removeByFilter')).to.be.true
        })
        it('toString is attached to proto', function () {
            expect(Sumator.prototype.hasOwnProperty('toString')).to.be.true
        })
        it('data length should be 0', function () {
            expect(mySumator.data.length).to.be.equal(0)
        })
    })
    describe('add tests', function () {
        it('add should add number type element into data', function () {
            mySumator.add(2)
            mySumator.add(3)
            expect(mySumator.data.length).to.be.equal(2)
        })
        it('add should add string element into data', function () {
            mySumator.add('test')
            expect(mySumator.data.length).to.be.equal(1)
        })
        it('add should add any type element into data', function () {
            mySumator.add(2)
            mySumator.add('pesho')
            expect(mySumator.data.length).to.be.equal(2)
        })
    })
    describe('sumNums tests', function () {
        it('sumNums should return 0', function () {
            expect(mySumator.sumNums()).to.be.equal(0)
        })
        it('sumNums should return 4', function () {
            mySumator.add(2)
            mySumator.add(2)
            mySumator.add('pesho')
            expect(mySumator.sumNums()).to.be.equal(4)
        })
        it('sumNums should return 0', function () {
            mySumator.add('pesho')
            mySumator.add('test')
            expect(mySumator.sumNums()).to.be.equal(0)
        })
    })
    describe('removeByFilter tests', function () {
        it('removeByFilter should return only odd', function () {
            for (let i = 0; i < 5; i++) {
                mySumator.add(i)
            }
            mySumator.removeByFilter(x => x % 2 === 0)

            expect(mySumator.data.length).to.be.equal(2)
        })
        it('removeByFilter should return only even', function () {
            for (let i = 0; i < 5; i++) {
                mySumator.add(i)
            }
            mySumator.removeByFilter(x => x % 2 !== 0)

            expect(mySumator.data.length).to.be.equal(3)
        })
    })
    describe('toString tests',function () {
        it('toString should return empty', function () {
            expect(mySumator.toString()).to.be.equal('(empty)')
        })
        it('toString should return string of items', function () {
            mySumator.add(2)
            mySumator.add(3)
            mySumator.add('test')
            expect(mySumator.toString()).to.be.equal('2, 3, test')
        })
    })
})