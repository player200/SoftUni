let jsdom = require('jsdom-global')()
let $ = require('jquery')
const sharedObject = require('../SharedObject/shared-object').sharedObject
let expect = require('chai').expect

document.body.innerHTML =
    `<div id="wrapper">
<input type="text" id="name">
<input type="text" id="income">
</div>`

describe("Shared Object", function () {
    before(() => global.$ = $)
    describe("Name", function () {
        it("should return null for name", function () {
            expect(sharedObject['name']).to.be.null
        })
    })
    describe("Income", function () {
        it("should return null for income", function () {
            expect(sharedObject['income']).to.be.null
        })
    })
    describe("Change name", function () {
        it("should return null for changeName()", function () {
            sharedObject.changeName('')
            expect(sharedObject['name']).to.be.null
        })
        it("should return test for changeName(test)", function () {
            sharedObject.changeName('test')
            expect(sharedObject['name']).to.be.equal('test')
        })
        it("should return test for changeName(test)", function () {
            sharedObject.changeName('test')
            expect(sharedObject['name']).to.be.equal('test')
        })
        it("should return test for changeName(test)", function () {
            sharedObject.changeName('test')
            let name=$('#name').val()
            expect(sharedObject['name']).to.be.equal('test')
            expect(name).to.be.equal('test')
        })
    })
    describe("Change income", function () {
        it("should return null for changeIncome(test)", function () {
            sharedObject.changeIncome('test')
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for changeIncome(2.2)", function () {
            sharedObject.changeIncome(2.2)
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for changeIncome(0)", function () {
            sharedObject.changeIncome(0)
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for changeIncome(-1)", function () {
            sharedObject.changeIncome(-1)
            expect(sharedObject['income']).to.be.null
        })
        it("should return 1 for changeIncome(1)", function () {
            sharedObject.changeIncome(1)
            let incomeTest = Number($('#income').val())
            expect(sharedObject['income']).to.be.equal(1)
            expect(incomeTest).to.be.equal(sharedObject['income'])
        })
        it("should return 5 for changeIncome(5)", function () {
            sharedObject.changeIncome(5)
            let incomeTest = Number($('#income').val())
            expect(sharedObject['income']).to.be.equal(5)
            expect(incomeTest).to.be.equal(sharedObject['income'])
        })
    })
    describe("Update name", function () {
        beforeEach(function () {
            $("#name").val('')
            sharedObject['name'] = null
        })
        it("should return null for updateName()", function () {
            sharedObject.updateName()
            expect(sharedObject['name']).to.be.null
        })
        it("should return test for updateName(test)", function () {
            $("#name").val('test')
            sharedObject.updateName()
            expect(sharedObject['name']).to.be.equal('test')
        })
    })
    describe("Update income", function () {
        beforeEach(function () {
            $("#income").val('')
            sharedObject['income'] = null
        })
        it("should return null for updateIncome()", function () {
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for updateIncome(3.5)", function () {
            $("#income").val('3.5')
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for updateIncome(test)", function () {
            $("#income").val('test')
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for updateIncome(0)", function () {
            $("#income").val('0')
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.null
        })
        it("should return null for updateIncome(-1)", function () {
            $("#income").val('-1')
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.null
        })
        it("should return 3 for updateIncome(3)", function () {
            $("#income").val('3')
            sharedObject.updateIncome()
            expect(sharedObject['income']).to.be.equal(3)
        })
    })
})