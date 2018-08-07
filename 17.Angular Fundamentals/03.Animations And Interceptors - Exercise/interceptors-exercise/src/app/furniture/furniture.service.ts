import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { CreateFurnitureModel } from './models/create-furniture.model'
import { AllFurnitureModel } from './models/all-furniture.model';

const createUrl = 'http://localhost:5000/furniture/create'
const allUrl = 'http://localhost:5000/furniture/all'
const myUrl = 'http://localhost:5000/furniture/mine'
const detailsUrl = 'http://localhost:5000/furniture/details/'
const deleteUrl = 'http://localhost:5000/furniture/delete/'

@Injectable({
    providedIn: 'root'
})
export class FurnitureService {
    constructor(private http: HttpClient) { }

    createFurniture(body: CreateFurnitureModel) {
        return this.http.post(createUrl, body)
    }

    getAllFurniture() {
        return this.http.get<AllFurnitureModel[]>(allUrl)
    }

    getFurnitureDetails(id: string) {
        return this.http.get<AllFurnitureModel>(detailsUrl + id)
    }

    getMyFurniture() {
        return this.http.get<AllFurnitureModel[]>(myUrl)
    }

    deleteFurniture(id: string) {
        return this.http.delete(deleteUrl + id)
    }
}