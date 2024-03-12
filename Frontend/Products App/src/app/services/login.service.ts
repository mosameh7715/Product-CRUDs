import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../models/login';
import { environment } from 'src/environments/environment.development';
import { BehaviorSubject, Subject, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private url: string = environment.apiDomain;
  isLoggedIn = new Subject<boolean>();
  loggedIn = new BehaviorSubject<boolean>(false);
  hasPermission: boolean = false;
  constructor(private http: HttpClient) {
    this.loggedIn.subscribe({
      next: (res: boolean) => {
        this.hasPermission = res;
      },
    });
  }

  login(loginData: Login) {
    return this.http.post(this.url + '/api/Account', loginData);
  }

  getLoggedInUser() {
    return this.http.get(this.url + '/api/Account');
  }
}
