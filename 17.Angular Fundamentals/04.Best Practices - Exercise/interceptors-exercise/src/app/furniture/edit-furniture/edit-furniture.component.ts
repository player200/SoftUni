import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../furniture.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AllFurnitureModel } from '../models/all-furniture.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-furniture',
  templateUrl: './edit-furniture.component.html',
  styleUrls: ['./edit-furniture.component.css']
})
export class EditFurnitureComponent implements OnInit {
  bindModel: AllFurnitureModel
  constructor(
    private furnitureService: FurnitureService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router) {
  }

  ngOnInit() {
    this.furnitureService.getFurnitureById(this.route.snapshot.params['id'])
      .subscribe(data => {
        this.bindModel = data
      })
  }

  edit() {
    this.furnitureService
      .editFurniture(this.bindModel.id, this.bindModel)
      .subscribe(() => {
        this.toastr.success('Edited successful', 'Success!')
        this.router.navigate(['/furniture/all'])
      })
  }
}
