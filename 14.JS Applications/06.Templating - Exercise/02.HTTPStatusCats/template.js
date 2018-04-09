$(() => {
    renderCatTemplate()

    async function renderCatTemplate() {
        let cats = window.cats
        let source = await $.get('cat-template.hbs')
        let compiled = Handlebars.compile(source)
        let template = compiled({
            cats
        })

        $('body').append(template)

        $('button').click((ev) => {
            let target = $(ev.target)
            let infoDiv = target.next()

            let text = target.text()
            if (text.includes('Show')) {
                target.text(text.replace('Show','Hide'))
            }
            else {
                target.text(text.replace('Hide','Show'))
            }

            infoDiv.toggle()
        })
    }
})
