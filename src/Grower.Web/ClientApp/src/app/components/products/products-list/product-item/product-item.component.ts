import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { count, zip } from 'rxjs';
import { RoleTypeEnum } from 'src/app/models/Enum/role.enum';
import { Order } from 'src/app/models/order.model';
import { Product } from 'src/app/models/product.model';
import { UserService } from 'src/app/services/userService';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css'],
})
export class ProductItemComponent implements OnInit {
  @Input() product: Product;
  @Input() selectionOrder: Order[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit(): void {}

  onEdit() {
    if (this.isGrower)
      this.router.navigate(['products/' + this.product.id + '/edit']);
  }
  get currentUser() {
    return this.userService._currenUser;
  }
  get isCustomer() {
    return this.currentUser.role.find(function (_role) {
      return _role === RoleTypeEnum.customer;
    });
  }
  get isGrower() {
    return this.currentUser.role.find(function (_role) {
      return _role === RoleTypeEnum.grower;
    });
  }

  selectOrder(value: any) {
    let itemIndex = this.selectionOrder.findIndex((x) => x.id == value);
    if (itemIndex != undefined && itemIndex > -1) {
      this.selectionOrder[itemIndex].count++;
    } else this.selectionOrder.push(new Order(value, 1));
    console.log(this.selectionOrder)
  }
}
