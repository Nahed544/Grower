import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductResolverService } from 'src/app/resolvers/product-list.resolver';
import { ProductTypeResolverService } from 'src/app/resolvers/ProductType.resolver';
import { ProductEditComponent } from './products-list/product-edit/product-edit.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsComponent } from './products.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    children: [
      {
        path: '',
        component: ProductsListComponent,
        resolve: [ProductResolverService],
      },
      {
        path: 'new',
        component: ProductEditComponent,
        resolve: [ProductTypeResolverService],
      },
      {
        path: ':id/edit',
        component: ProductEditComponent,
        resolve: [ProductTypeResolverService],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductsRoutingModule {}
