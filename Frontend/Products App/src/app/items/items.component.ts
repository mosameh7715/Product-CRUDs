import { Component, OnInit } from '@angular/core';
import { ItemService } from '../services/item.service';
import { Product } from '../models/Product';
import { Result } from '../interfaces/result.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { AuthorizeService } from '../services/authorize.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css'],
})
export class ItemsComponent implements OnInit {
  items: Product[] = [];
  totalCount: number = 9;
  currentPage: number = 1;
  search: string = '';
  hasPermission: boolean = false;

  constructor(
    private itemService: ItemService,
    private route: Router,
    private router: ActivatedRoute,
    private loginService: LoginService,
    private authorizeService: AuthorizeService
  ) {}

  ngOnInit() {
    this.loginService.loggedIn.subscribe({
      next: (res: boolean) => {
        this.hasPermission = res;
      },
    });
    this.getAll();
    this.itemService.refresh.subscribe({
      next: () => {
        this.getAll();
      },
    });
  }

  ChangeCurrentPage(page: Event) {
    this.currentPage = +page;
    this.getAll();
  }

  onSearch(searchContent: string) {
    this.search = searchContent;
    this.currentPage = 1;
    this.getAll();
  }

  getAll() {
    this.itemService.getAllItems(this.currentPage, this.search).subscribe({
      next: (response: Result) => {
        this.items = response.result.resultSet as Product[];
        this.totalCount = Math.max(response.result.count, 9);
        console.log(response);
        console.log(this.items);
      },
    });
  }

  // onGetSingleItem(id: number) {
  //   this.route.navigate([`${id}`], { relativeTo: this.router });
  // }
  onCreateItem() {
    this.route.navigate(['create/new'], { relativeTo: this.router });
  }
}
