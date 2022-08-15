import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { environment } from "src/environments/environment";
import { Product } from "../models/product.model";
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.baseURL;
  productsChanged = new Subject<Product[]>();
  products: Product[] = [];
  growerId: number = 1 ;

  constructor(private httpClient: HttpClient) {

  }

  getProduct(id : number) {
   return this.products.filter(function(element){ return element.id == id; })
  }
  getProducts() {
    if(this.products.length <= 0)
    {    
      this.fetchProducts();
    } 
    return this.products ;
  }

  fetchProducts() {  
     return this.httpClient.get<Product[]>(this.baseUrl + 'Product?growerId=' + this.growerId).pipe(
      map((res: Product[]) => {
        return res;
      }), tap((result) => { this.products = result; }
      )
    );
  }

  addProduct(product:Product){ 
  product.growerId = 1;
   return this.httpClient.post(this.baseUrl + 'Product' ,product);
  }

}