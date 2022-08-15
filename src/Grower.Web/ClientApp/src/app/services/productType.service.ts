import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map ,tap} from "rxjs";
import { environment } from "src/environments/environment";
import { ProductType } from "../models/productType.model";

@Injectable({
    providedIn: 'root'
  })
  export class ProductTypeService {
    productTypes : ProductType[] ;
    baseUrl = environment.baseURL;
    
    constructor(private httpClient: HttpClient) {

    }
    getProductTypes() {
        if( !this.productTypes || this.productTypes?.length <= 0)
        {    
          this.fetchProductTypes();
        } 
        return this.productTypes ;
      }
    
      fetchProductTypes() {  
         return this.httpClient.get<ProductType[]>(this.baseUrl + 'ProductType' ).pipe(
          map((res: ProductType[]) => {
            return res;
          }),
           tap((result) => { this.productTypes= result; }
          //  ,
          //  (error)=>{
          //   console.log(error)
          // }
          )
        );
      }
  }