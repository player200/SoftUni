function attachEvents() {
    $('#btnLoadTowns').on('click', function () {
        let towns = $('#towns')
            .val()
            .split(', ')
            .map(t => ({
                town: t
            }))

        loadTowns(towns)
    })

    async function loadTowns(towns) {
        let source = await $.get('town-template.hbs')
        let compiled = Handlebars.compile(source)
        let template = compiled({
            towns
        })

        $('#root')
            .html(template)
    }
}