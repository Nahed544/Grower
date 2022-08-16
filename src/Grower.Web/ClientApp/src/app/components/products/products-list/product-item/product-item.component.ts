import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

@Input()  product:Product ;

  constructor(private router: Router ,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onEdit(){
    this.router.navigate(['products/' + this.product.id+'/edit'])
  }
}
