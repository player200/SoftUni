import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyFurnitureComponent } from './my-furniture/my-furniture.component';
import { FurnituresDetailsComponent } from './furnitures-details/furnitures-details.component';
import { CreateFurnitureComponent } from './create-furniture/create-furniture.component';
import { AllFurnitureComponent } from './all-furniture/all-furniture.component';
import { EditFurnitureComponent } from './edit-furniture/edit-furniture.component';

const furnitureRoutes: Routes = [
    { path: 'all', component: AllFurnitureComponent },
    { path: 'create', component: CreateFurnitureComponent },
    { path: 'details/:id', component: FurnituresDetailsComponent },
    { path: 'mine', component: MyFurnitureComponent },
    { path: 'edit/:id', component: EditFurnitureComponent }
]

@NgModule({
    imports: [
        RouterModule.forChild(furnitureRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class FurnitureRoutingModule { }