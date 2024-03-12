import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/Product';
import { ItemService } from 'src/app/services/item.service';
import { LoginService } from 'src/app/services/login.service';
import { environment } from 'src/environments/environment.development';
import { Location } from '@angular/common';

@Component({
  selector: 'app-itemcard',
  templateUrl: './itemcard.component.html',
  styleUrls: ['./itemcard.component.css'],
})
export class ItemcardComponent {
  @Input() item: Product;
  imgUrl: string;
  showModal: boolean = false;
  hasPermission: boolean = false;

  constructor(
    private itemservice: ItemService,
    private route: ActivatedRoute,
    private router: Router,
    private loginService: LoginService,
    private location: Location
  ) {}
  ngOnInit() {
    this.imgUrl = environment.apiDomain + '/' + this.item.imgUrl;
    this.hasPermission = this.loginService.hasPermission;
  }
  onUpdateItem() {
    this.router.navigate([`create/${this.item.id}`], {
      relativeTo: this.route,
    });
  }
  deleteItem(id: number) {
    this.showModal = false;
    this.itemservice.DeleteItem(id).subscribe({
      next: (response) => {
        console.log(response);
      },
    });
  }

  say() {
    this.showModal = true;
  }

  onGetSingleItem(id: number) {
    this.router.navigate([`${id}`], { relativeTo: this.route });
  }
}
