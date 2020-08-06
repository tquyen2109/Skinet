import { IOrder } from './../shared/models/order';
import { OrdersService } from './orders.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  orders: IOrder[];
  constructor(private orderService: OrdersService) { }

  ngOnInit(): void {
    this.getOrders();
  }
  getOrders() {
    this.orderService.getOrdersForUser().subscribe((orders: IOrder[]) => {
      this.orders = orders;
    }, error => {
      console.log(error);
    });
  }

}
