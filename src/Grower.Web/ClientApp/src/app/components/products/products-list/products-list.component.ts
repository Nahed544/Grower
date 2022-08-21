import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router'; 
import { RoleTypeEnum } from 'src/app/models/Enum/role.enum';
import { Order } from 'src/app/models/order.model';
import { ProductService } from 'src/app/services/product.service'; 
import { UserService } from 'src/app/services/userService';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
})
export class ProductsListComponent implements OnInit {
  selectionOrder :Order []=[] ;
  
  constructor(private router: Router, private productService: ProductService ,
    private userService:UserService) {}

    
  ngOnInit(): void {
  }

  get products() {
    return this.productService.products;
  }
  onAdd() {
    this.router.navigate(['products/new']);
  }
  get currentUser() {
    return this.userService._currenUser;
  }
  get isGrower() {
    return this.currentUser.role.find(function (_role) {
      return _role === RoleTypeEnum.grower;
    });
  } 
  get isCustomer() {
    return this.currentUser.role.find(function (_role) {
      return _role === RoleTypeEnum.customer;
    });
  }
  createOrder(){
   console.log(this.selectionOrder.length)
  }
}
