import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  @Input() products: Product[] = [];
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onAdd(){
    this.router.navigate(['products/new'])
  }

}
