import { OrdersRoutingModule } from './orders-routing.module';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { SharedModule } from './../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';



@NgModule({
  declarations: [OrderComponent, OrderDetailComponent],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    OrdersRoutingModule
  ]
})
export class OrdersModule { }
