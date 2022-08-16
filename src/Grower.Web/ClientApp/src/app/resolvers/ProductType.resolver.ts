import { Injectable } from '@angular/core';
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';
import { Observable } from 'rxjs';
 import { ProductType } from '../models/productType.model';
import { ProductTypeService } from '../services/productType.service';
 
@Injectable({ providedIn: 'root' }) 

export class ProductTypeResolverService implements Resolve<ProductType[]> {
    constructor( 
        private productTypeService: ProductTypeService      ) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const productTypes = this.productTypeService.getProductTypes(); 
        if ( productTypes?.length === 0) {
          return this.productTypeService.fetchProductTypes();
        } else {
          return productTypes;
        }
      }
}