class PaymentManager {
    constructor(title) {
        this.title = title
        this.element = null
        this.elToRemove = null
    }

    render(target) {
        this.element = $(`<table>`)
        let caption = $(`<caption>${this.title} Payment Manager</caption>`)
        let thead = $('<thead><tr><th class="name">Name</th><th class="category">Category</th><th class="price">Price</th><th>Actions</th></tr></thead>')
        let tbody = $('<tbody class="payments"></tbody>')
        let tfoot = $('<tfoot class="input-data">')
        let tr = $('<tr>')
        let firstTd = $('<td><input name="name" type="text"></td>')
        let secondTd = $('<td><input name="category" type="text"></td>')
        let thirdTd = $('<td><input name="price" type="number"></td>')
        let td = $('<td>')
        let button = $('<button>Add</button>').on('click', this.add.bind(this))

        td.append(button)
        tr.append(firstTd)
        tr.append(secondTd)
        tr.append(thirdTd)
        tr.append(td)
        tfoot.append(tr)
        this.element.append(caption)
        this.element.append(thead)
        this.element.append(tbody)
        this.element.append(tfoot)

        target = '#' + target
        $(`${target}`).append(this.element)
    }

    add() {
        let name = this.element.find($('.input-data input[name=name]')).val()
        let category = this.element.find($('.input-data input[name=category]')).val()
        let price = this.element.find($('.input-data input[name=price]')).val()
        if(name===''||category===''||price===''){
            return
        }
        this.element.find($('.input-data input[name=name]')).val('')
        this.element.find($('.input-data input[name=category]')).val('')
        this.element.find($('.input-data input[name=price]')).val('')

        this.elToRemove = $('<tr>')
        let firstTd = $(`<td>${name}</td>`)
        let secondTd = $(`<td>${category}</td>`)
        let thirdTd = $(`<td>${Number(price)}</td>`)
        let fourthTd = $('<td>')
        let curr = this
        let btn = $('<button>Delete</button>').on('click', this.delete)

        fourthTd.append(btn)
        this.elToRemove.append(firstTd)
        this.elToRemove.append(secondTd)
        this.elToRemove.append(thirdTd)
        this.elToRemove.append(fourthTd)

        this.element.find($('.payments')).append(this.elToRemove)
    }

    delete() {
        $(this).closest('tr').remove()
    }
}