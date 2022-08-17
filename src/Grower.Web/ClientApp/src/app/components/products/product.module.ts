import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router"; 
import { ProductEditComponent } from "./products-list/product-edit/product-edit.component";
import { ProductItemComponent } from "./products-list/product-item/product-item.component";
import { ProductsListComponent } from "./products-list/products-list.component";
import { ProductsRoutingModule } from "./products-routing.module";
import { ProductsComponent } from "./products.component";

@NgModule({
declarations:[ 
    ProductsComponent,
    ProductsListComponent,
    ProductItemComponent,
    ProductEditComponent

],
 imports:[RouterModule  ,
    ReactiveFormsModule ,
    ProductsRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule
     
] 
})
export class ProductsModule{

}