import { OrdersService } from './../orders.service';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from './../../shared/models/order';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  order: IOrder;
  constructor(private route: ActivatedRoute, private breadcrumbService: BreadcrumbService,
              private ordersService: OrdersService) {
      this.breadcrumbService.set('@OrderDetailed', '');
     }

  ngOnInit(): void {
    this.ordersService.getOrdersDetailed(+this.route.snapshot.paramMap.get('id')).subscribe((order:IOrder) => {
      this.order = order;
      this.breadcrumbService.set('@OrderDetailed', `Order# ${order.id} - ${order.status}`);
    }, error => {
      console.log(error);
    });
  }

}
