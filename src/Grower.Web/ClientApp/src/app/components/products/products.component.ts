import { Component, OnInit } from '@angular/core';
import { Subscriber, Subscription } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductType } from 'src/app/models/productType.model';
import { ProductService } from 'src/app/services/product.service';
import { ProductTypeService } from 'src/app/services/productType.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Product[] = [];
  productTypes: ProductType[] =[] ;

  constructor(private productService: ProductService ,
    private productTypeService :ProductTypeService) { }

  ngOnInit(): void {  
   
    this.products =  this.productService.products; 
    this.productTypes = this.productTypeService.productTypes ;
    console.log(this.productTypes)
  }

}
