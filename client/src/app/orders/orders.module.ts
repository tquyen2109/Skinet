import { SharedModule } from './../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';



@NgModule({
  declarations: [OrderComponent],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ]
})
export class OrdersModule { }
