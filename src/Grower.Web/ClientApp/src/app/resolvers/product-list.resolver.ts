import { Injectable } from '@angular/core';
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

   

@Injectable({ providedIn: 'root' })
export class ProductResolverService implements Resolve<Product[]> {
  constructor( 
    private productService: ProductService
  ) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const producs = this.productService.getProducts(); 
    if (producs.length === 0) {
      return this.productService.fetchProducts();
    } else {
      return producs;
    }
  }
}
