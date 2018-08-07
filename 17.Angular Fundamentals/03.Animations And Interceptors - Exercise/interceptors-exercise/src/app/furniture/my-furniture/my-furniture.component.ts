import { Component, OnInit } from '@angular/core';
import { AllFurnitureModel } from '../models/all-furniture.model';
import { Observable } from 'rxjs';
import { FurnitureService } from '../furniture.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-furniture',
  templateUrl: './my-furniture.component.html',
  styleUrls: ['./my-furniture.component.css']
})
export class MyFurnitureComponent implements OnInit {
  furnitures: Observable<AllFurnitureModel[]>
  constructor(private furnitureService: FurnitureService,
  private router:Router) { }

  ngOnInit() {
    this.furnitures = this.furnitureService.getMyFurniture()
  }

  delete(id: string) {
    this.furnitureService.deleteFurniture(id)
    .subscribe(()=>{
      this.router.navigate(['/furniture/all'])
    })
  }
}
