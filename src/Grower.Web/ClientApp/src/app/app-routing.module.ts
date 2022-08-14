import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProductEditComponent } from './components/products/products-list/product-edit/product-edit.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductResolverService } from './resolvers/product-list.resolver';



const appRoutes: Routes = [
  { path: '', pathMatch: 'full' ,redirectTo:'/products'}
  ,
  { path: '' ,
    children:
    [
      {path:'products', component: ProductsComponent  ,resolve:[ProductResolverService]} ,
      {path: 'products/new', component: ProductEditComponent} ,  
      {path: 'products/:id/edit', component: ProductEditComponent,resolve:[ProductResolverService] }
    
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
