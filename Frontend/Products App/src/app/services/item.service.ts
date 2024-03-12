import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Product } from '../models/Product';
import { Result } from '../interfaces/result.interface';
import { Subject } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  pageSize: number = 9;
  singleItem = new Subject<Product>();
  refresh: Subject<void> = new Subject<void>();
  private url: string = environment.apiDomain + '/api/Products';
  constructor(private http: HttpClient) {}

  getAllItems(pageNumber: number = 1, search: string = '') {
    return this.http.get<Result>(
      this.url +
        `?pageSize=${this.pageSize}&pageNumber=${pageNumber}&search=${search}`
    );
  }
  GetItem(id: number) {
    return this.http.get(`${this.url}/${id}`);
  }
  PostItem(item: Product) {
    return this.http.post(this.url, item);
  }
  PutItem(item: Product) {
    return this.http.put(`${this.url}/${item.id}`, item);
  }
  DeleteItem(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }

  PostFormData(item: FormData) {
    return this.http.post(`${this.url}`, item);
  }

  PutFormData(item: FormData, id: number) {
    return this.http.put(`${this.url}/${id}`, item);
  }
}
