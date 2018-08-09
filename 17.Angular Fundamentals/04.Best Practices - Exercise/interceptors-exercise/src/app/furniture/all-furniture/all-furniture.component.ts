import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../furniture.service';
import { AllFurnitureModel } from '../models/all-furniture.model';
import { Observable } from 'rxjs'
import { AuthService } from '../../authentication/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-furniture',
  templateUrl: './all-furniture.component.html',
  styleUrls: ['./all-furniture.component.css']
})
export class AllFurnitureComponent implements OnInit {
  pageSize: number = 1
  currentPage: number = 1
  furnitures: Observable<AllFurnitureModel[]>
  constructor(
    private furnitureService: FurnitureService,
    private authService: AuthService) { }

  ngOnInit() {
    this.furnitures = this.furnitureService.getAllFurniture()
  }

  pageChanged(page) {
    this.currentPage = page
  }

  delete(id: string) {
    this.furnitureService.deleteFurniture(id)
      .subscribe(() => {
        this.furnitures = this.furnitureService.getAllFurniture()
      })
  }
}
