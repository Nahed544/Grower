import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { pipe, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';
import { map, tap } from 'rxjs/operators';
import { UserService } from './userService';
import { RoleTypeEnum } from '../models/Enum/role.enum';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl = environment.baseURL;
  productsChanged = new Subject<Product[]>();
  products: Product[] = [];
  growerId: number = 1;

  constructor(
    private httpClient: HttpClient,
    private userService: UserService
  ) {}

  getProduct(id: number) {
    return this.products.filter(function (element) {
      return element.id == id;
    });
  }
  getProducts() {
    if (this.products.length <= 0) {
      this.fetchProducts();
    }
    return this.products;
  } 
  fetchProducts() {
    if (this.isCustomer) {
      return this.httpClient.get<Product[]>(this.baseUrl + 'Product').pipe(
        map((res: Product[]) => {
          return res;
        }),
        tap((result) => {
          this.products = result;
        })
      );
    } else {
      return this.httpClient
        .get<Product[]>(this.baseUrl + 'Product/' + this.growerId)
        .pipe(
          map((res: Product[]) => {
            return res;
          }),
          tap((result) => {
            this.products = result;
          })
        );
    }
  }

  addProduct(product: Product) {
    product.growerId = 1;
    return this.httpClient.post(this.baseUrl + 'Product', product).pipe(
      tap(() => {
        this.products.push(product);
        this.productsChanged.next(this.products.slice());
      })
    );
  }

  deleteProduct(id: number) {
    return this.httpClient.delete(this.baseUrl + 'Product/' + id).pipe(
      tap(() => {
        const indexOfProduct = this.products.findIndex((product) => {
          return product.id === id;
        });
        if (indexOfProduct && indexOfProduct > 0) {
          this.products.splice(indexOfProduct, 1);
          this.productsChanged.next(this.products.slice());
        }
      })
    );
  }
  updateProduct(product: Product, productId: number) {
    product.growerId = 1;
    product.id = productId;

    return this.httpClient.put<Product>(this.baseUrl + 'Product', product).pipe(
      tap(() => {
        const indexOfProduct = this.products.findIndex((_product) => {
          return _product.id === product.id;
        });
        if (indexOfProduct && indexOfProduct > 0) {
          this.products[indexOfProduct] = product;
          this.productsChanged.next(this.products.slice());
        }
      })
    );
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
}
