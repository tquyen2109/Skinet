import { OrderDetailComponent } from './order-detail/order-detail.component';
import { Routes, RouterModule } from '@angular/router';
import { OrderComponent } from './order.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {path: '', component: OrderComponent},
  {path: ':id', component: OrderDetailComponent, data: {breadcrumb: {alias: 'OrderDetailed'}}}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
