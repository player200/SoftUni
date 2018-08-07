import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../furniture.service';
import { AllFurnitureModel } from '../models/all-furniture.model';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs'

@Component({
  selector: 'app-furnitures-details',
  templateUrl: './furnitures-details.component.html',
  styleUrls: ['./furnitures-details.component.css']
})
export class FurnituresDetailsComponent implements OnInit {
  bindModel: Observable<AllFurnitureModel>
  id: string
  constructor(private furnitureService: FurnitureService,
    private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['id']
  }

  ngOnInit() {
    this.bindModel = this.furnitureService.getFurnitureDetails(this.id)
  }

}
