let jsdom = require('jsdom-global')()
let $ = require('jquery')
const nuke = require('../ArmageDOM/armagedom').nuke
let expect = require('chai').expect


describe("Shared Object", function () {
    beforeEach(function () {
        document.body.innerHTML = `<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>`
    })

    before(() => global.$ = $)
    describe("Name", function () {
        it("should return untouchedHtml for nuke(html,html)", function () {
            let select = $('#target').html()
            nuke(select, select)
            let oldSelect = $('#target').html()
            expect(select).to.be.equal(oldSelect)
        })
        it("should return untouchedHtml for nuke(html)", function () {
            let select = $('#target').html()
            let selectorOne = $('.target')
            nuke(selectorOne)
            let oldSelect = $('#target').html()
            expect(select).to.be.equal(oldSelect)
        })
        it("should return untouchedHtml for nuke(html,string)", function () {
            let select = $('#target').html()
            let selectOne = $('.target')
            let selectorTwo = $('dwadad')
            nuke(selectOne, selectorTwo)
            let oldSelect = $('#target').html()
            expect(select).to.be.equal(oldSelect)
        })
        it("should return not be equal for nuke(html,html)", function () {
            let select = $('#target').html()
            let selectOne = '.target'
            let selectTwo = '.nested'
            nuke(selectTwo, selectOne)
            let oldSelect = $('#target').html()
            expect(select).to.not.be.equal(oldSelect)
        })
        it("should return untouchedHtml for nuke(html,html)", function () {
            let select = $('#target').html()
            let selectOne = '.inside'
            let selectTwo = '.nested'
            nuke(selectTwo, selectOne)
            let oldSelect = $('#target').html()
            expect(select).to.be.equal(oldSelect)
        })
    })
})