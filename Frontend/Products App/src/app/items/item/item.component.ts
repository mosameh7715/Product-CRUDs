import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Result } from 'src/app/interfaces/result.interface';
import { SingleResult } from 'src/app/interfaces/singleResult.interface';
import { Product } from 'src/app/models/Product';
import { ItemService } from 'src/app/services/item.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css'],
})
export class ItemComponent implements OnInit {
  item: Product = new Product(0, '', 0, '', '', '', 0);
  hasImg: boolean = false;

  constructor(
    private itemService: ItemService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe((params: Params) => {
      this.item.id = params['id'];
    });
  }

  ngOnInit() {
    this.itemService.GetItem(this.item.id).subscribe({
      next: (result: SingleResult) => {
        this.item = <Product>result.result;
        if (this.item.imgUrl != null) {
          this.hasImg = true;
          this.item.imgUrl = environment.apiDomain + '/' + this.item.imgUrl;
        }
      },
    });
  }

  backToItems() {
    this.router.navigate(['/items'], { relativeTo: this.route });
  }
}
