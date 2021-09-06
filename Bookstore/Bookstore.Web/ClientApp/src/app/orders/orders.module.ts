import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersDetailComponent } from './orders-detail/orders-detail.component';
import { OrdersNewComponent } from './orders-new/orders-new.component';
import { OrdersComponent } from './orders.component';
import {ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [OrdersDetailComponent, OrdersNewComponent, OrdersComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule
    ]
})
export class OrdersModule { }
