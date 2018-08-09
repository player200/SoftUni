import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms';
import { FurnitureService } from './furniture.service';
import { furnitureComponents } from './index';
import { FurnitureRoutingModule } from './furniture-routing.module';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
    declarations: [
        ...furnitureComponents
    ],
    imports: [
        CommonModule,
        FormsModule,
        FurnitureRoutingModule,
        NgxPaginationModule
    ],
    providers: [
        FurnitureService
    ]
})
export class FurnitureModule { }