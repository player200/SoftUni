class Repository {
    constructor(prop) {
        this.prop = prop
        this.data = new Map()
        this.id = 0
    }

    add(entity) {
        this._validateData(entity)
        this.data.set(this.id, entity)
        return this.id++
    }

    get(index){
        if(!this.data.has(index)){
            throw new Error()
        }
        return this.data.get(index)
    }

    update(index,newEntity){
        if(!this.data.has(index)){
            throw new Error()
        }
        this._validateData(newEntity)
        this.data.set(index,newEntity)
    }

    del(index){
        if(!this.data.has(index)){
            throw new Error()
        }
        this.data.delete(index)
    }

    get count(){
        return this.data.size
    }

    _validateData(entity) {
        for (let key in this.prop) {
            if (!entity.hasOwnProperty(key)) {
                throw new TypeError()
            }
            if (this.prop[key] !== typeof (entity[key])) {
                throw new TypeError()
            }
        }
    }
}