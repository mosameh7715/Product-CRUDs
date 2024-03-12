import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Result } from 'src/app/interfaces/result.interface';
import { SingleResult } from 'src/app/interfaces/singleResult.interface';
import { Category } from 'src/app/models/category';
import { Product } from 'src/app/models/Product';
import { ItemService } from 'src/app/services/item.service';
import { SweatAlert } from 'src/app/services/sweat-alert.service';

@Component({
  selector: 'app-create-item',
  templateUrl: './create-item.component.html',
  styleUrls: ['./create-item.component.css'],
})
export class CreateItemComponent implements OnInit {
  createItem: FormGroup;
  item: Product = new Product(
    0,
    '',
    0,
    '',
    '',
    '../../../assets/images/item1.jpg',
    0
  );
  categories: { id: number; name: string }[];
  isUpdateMode: boolean = false;
  isChangesSaved: boolean = false;
  sweatAlertService: SweatAlert = new SweatAlert();

  constructor(
    private router: ActivatedRoute,
    private itemService: ItemService,
    private route: Router
  ) {
    this.router.params.subscribe((params: Params) => {
      //CHECK IF THE ID HAS RIGHT ID
      if (!isNaN(params['id'])) {
        this.isUpdateMode = true;
        this.item.id = params['id'];
        this.itemService.GetItem(this.item.id).subscribe({
          next: (result: SingleResult) => {
            this.item = <Product>result.result;
            console.log(result);
          },
          error: (error) => {
            this.route.navigate(['/notfound'], { relativeTo: this.router });
          },
        });
      }
    });
  }
  ngOnInit() {
    this.createItem = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required]),
      description: new FormControl(null),
      image: new FormControl(null),
      brand: new FormControl(null),
      quantity: new FormControl(null, [Validators.required]),
    });
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('image', this.createItem.get('image').value);
    formData.append('name', this.createItem.value.name);
    formData.append('price', this.createItem.value.price);
    formData.append('description', this.createItem.value.description);
    formData.append('brand', this.createItem.value.brand);
    formData.append('quantity', this.createItem.value.quantity);

    if (!this.isUpdateMode) {
      this.itemService.PostFormData(formData).subscribe({
        next: (response) => {
          this.isChangesSaved = true;
          this.sweatAlertService.successNotification(this.isUpdateMode);
          this.route.navigate(['/items'], { relativeTo: this.router });
        },
        error: (err) => {
          if (err.error.ErrorMessages[0] === 'Category Not Exists!') {
            alert('please select category!');
            console.clear();
          }
        },
      });
    } else {
      this.itemService.PutFormData(formData, this.item.id).subscribe({
        next: (response) => {
          this.isChangesSaved = true;
          this.sweatAlertService.successNotification(this.isUpdateMode);
          this.route.navigate(['/items'], { relativeTo: this.router });
        },
        error: (err: HttpErrorResponse) => {
          if (err.error.ErrorMessages[0] === 'Category Not Exists!') {
            alert('please select category!');
            console.clear();
          }
        },
      });
    }
  }

  backToItems() {
    this.route.navigate(['/items'], { relativeTo: this.router });
  }

  canDeactivate(): boolean | Promise<boolean> | Observable<boolean> {
    return new Promise<boolean>((resolve) => {
      if (!this.createItem.valid || !this.isChangesSaved) {
        this.sweatAlertService.alertSkipEdit().then((isConfirmed) => {
          resolve(isConfirmed);
        });
      } else {
        resolve(true);
      }
    });
  }

  onFileSelect(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.createItem.get('image').setValue(file);
    }
  }
}
