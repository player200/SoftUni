import { Component, OnInit } from '@angular/core';
import { CreateFurnitureModel } from '../models/create-furniture.model';
import { FurnitureService } from '../furniture.service';

@Component({
  selector: 'app-create-furniture',
  templateUrl: './create-furniture.component.html',
  styleUrls: ['./create-furniture.component.css']
})
export class CreateFurnitureComponent implements OnInit {
  bindModel: CreateFurnitureModel
  constructor(private furnitureService: FurnitureService) {
    this.bindModel = new CreateFurnitureModel('', '', 0, '', 1, '')
  }

  ngOnInit() {
  }

  create() {
    this.furnitureService.createFurniture(this.bindModel)
      .subscribe()
  }
}
