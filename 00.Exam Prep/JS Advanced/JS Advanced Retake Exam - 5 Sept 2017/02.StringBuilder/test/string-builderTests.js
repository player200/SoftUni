let expect = require('chai').expect
let StringBuilder = require('../string-builder')

describe('StringBuilder Unit Tests', function () {
    let myBuilder
    beforeEach(function () {
        myBuilder = new StringBuilder()
    })

    describe('Initial tests', function () {
        it('props are attached to proto', function () {
            expect(StringBuilder.prototype.hasOwnProperty('append')).to.be.equal(true)
            expect(StringBuilder.prototype.hasOwnProperty('prepend')).to.be.equal(true)
            expect(StringBuilder.prototype.hasOwnProperty('insertAt')).to.be.equal(true)
            expect(StringBuilder.prototype.hasOwnProperty('remove')).to.be.equal(true)
            expect(StringBuilder.prototype.hasOwnProperty('toString')).to.be.equal(true)
        })
        it('_stringArray length should throw error', function () {
            expect(() => new StringBuilder({})).to.throw(TypeError)
        })
        it('_stringArray length should work', function () {
            let test = new StringBuilder('str')
            expect(test._stringArray.length).to.be.equal(3)
            expect(test.toString()).to.be.equal('str')
        })
    })
    describe('append tests', function () {
        it('append should throw error', function () {
            expect(() => myBuilder.append({})).to.throw(TypeError)
        })
        it('append should add str items in array', function () {
            let test = new StringBuilder('str')
            test.append(' str')
            expect(myBuilder._stringArray.length).to.be.equal(7)
            expect(test.toString()).to.be.equal('str str')
        })
    })
    describe('prepend tests', function () {
        it('prepend should add in start', function () {
            let test = new StringBuilder('str')
            test.prepend('eee ')
            expect(myBuilder._stringArray.length).to.be.equal(7)
            expect(test.toString()).to.be.equal('eee str')
        })
        it('prepend should throw error', function () {
            expect(()=>myBuilder.prepend({})).to.throw(TypeError)
        })
    })
    describe('insertAt tests', function () {
        it('insertAt should throw error', function () {
            expect(()=>myBuilder.insertAt({},3)).to.throw(TypeError)
        })
        it('insertAt should work', function () {
            myBuilder.insertAt('eee', 0)
            expect(myBuilder._stringArray.length).to.be.equal(3)
            expect(myBuilder.toString()).to.be.equal('eee')
        })
    })
    describe('remove tests', function () {
        it('return should work', function () {
            myBuilder.append('seat')
            myBuilder.remove(2, 1)
            expect(myBuilder._stringArray.length).to.be.equal(3)
            expect(myBuilder.toString()).to.be.equal('set')
        })
    })
})