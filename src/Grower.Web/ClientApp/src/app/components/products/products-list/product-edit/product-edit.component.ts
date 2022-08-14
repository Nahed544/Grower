import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  productForm: FormGroup;
  editMode = false;
  productId :number ;

  constructor(private productService: ProductService, private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.productId = +params['id']; 
      this.editMode = (params['id'] == undefined || params['id'] == NaN ) ? false : true ; 
      this.intializeForm();
    });

  }

  intializeForm() {
    if (this.editMode) {
      let product =  this.productService.getProduct(this.productId)?.[0];  
      this.productForm = this.fb.group({
        productName: [product.productName, Validators.required],
        productTypeId: [product.productTypeId, Validators.required],
        price: [product.price, Validators.required],
        image: [product.image],
        availability: [product.availability, Validators.required],
        quatity: [product.quatity, Validators.required],
        description: [product.description, Validators.required]
      });
      //this.editMode =false
    }
    else {
      this.productForm = this.fb.group({
        productName: ['', Validators.required],
        productTypeId: ['', Validators.required],
        price: ['', Validators.required],
        image: [''],
        availability: ['', Validators.required],
        quatity: ['', Validators.required],
        description: ['', Validators.required]
      });
    }
   

  }


  submit() {

    if (this.productForm.valid) {
      if(this.editMode) {
        
      }
      else
      {
        this.productService.addProduct(this.productForm.value).subscribe(
          () => {
            this.router.navigate(['products'])
          },
          (error) => {
            console.log(error)
          }
        )
      }
    }

  }

  Cancel() {
    this.productForm.reset();
    this.router.navigate(['products'])
  }
}
